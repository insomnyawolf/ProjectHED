using System;
using System.Threading;
using System.Text.RegularExpressions;
using MetroFramework.Controls;

namespace ProjectHEDio
{
    class WebsiteSafebooru : Website
    {
        public WebsiteSafebooru(MetroPanel sourcePanel) : base(sourcePanel)
        {
            
        }

        public override void InitializeScrape(string[] arguments = null, int limit = 1, bool limitByImages = false)
        {
            ScrapeThread = new Thread(() => Scrape(arguments, limit, limitByImages));
            ScrapeThread.IsBackground = true;
            ScrapeThread.Start();
        }

        protected override int GetMaxPages(string[] arguments = null)
        {
            string source = GetSource(FormatURL(arguments));
            string pattern = "<posts count=\\\"(?<TotalPosts>\\d+)\\\"";

            string match = Regex.Match(source, pattern).Groups["TotalPosts"].Value;

            if (!string.IsNullOrWhiteSpace(match))
            {
                int result = -1;
                if (int.TryParse(match, out result))
                {
                    if (result != 0)
                    {
                        return (int)((result / 40) + 1);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return -1;
        }

        protected override string FormatURL(string[] arguments = null, int pageNumber = 1)
        {
            return string.Format("https://safebooru.org/index.php?page=dapi&s=post&q=index&limit=40&pid={0}&tags={1}", (pageNumber - 1), GetTagList(arguments));
        }

        protected override void Scrape(string[] arguments = null, int limit = 1, bool limitByImages = false)
        {
            int pages = GetMaxPages(arguments);
            if (pages < 1)
            {
                return;
            }
            if (!limitByImages && limit < pages)
            {
                pages = limit;
            }

            ulong totalFound = 0;
            for (int i = 1; i <= pages; i++)
            {
                string source = GetSource(FormatURL(arguments, i));

                string postPattern = "<post[^>]+\\/>";
                MatchCollection mc = Regex.Matches(source, postPattern);
                foreach (Match m in mc)
                {
                    string postString = m.Value;
                    string linkPattern = "file_url=\"(?<Link>[^\\\"]+)\"";
                    string heightPattern = "<post height=\"(?<Height>\\d+)\"";
                    string widthPattern = "id=\"\\d+\" width=\"(?<Width>\\d+)";

                    string link = Regex.Match(postString, linkPattern).Groups["Link"].Value;
                    if (!link.Contains("http:"))
                    {
                        link = "http:" + link;
                    }
                    int width = -1;
                    int height = -1;
                    string widthCaptured = Regex.Match(postString, widthPattern).Groups["Width"].Value;
                    string heightCaptured = Regex.Match(postString, heightPattern).Groups["Height"].Value;
                    if (int.TryParse(widthCaptured, out width) && int.TryParse(heightCaptured, out height))
                    {
                        if (limitByImages)
                        {
                            if ((int)totalFound < limit)
                            {
                                AddToLinks(link, width, height);
                                totalFound++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            AddToLinks(link, width, height);
                            totalFound++;
                        }
                    }
                    else
                    {
                        if (limitByImages)
                        {
                            if ((int)totalFound < limit)
                            {
                                AddToLinks(link);
                                totalFound++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            AddToLinks(link);
                            totalFound++;
                        }
                    }
                }
                LogHelper.Log(string.Format("PAGE: Found {0} matches from page {1} of this {2} object.", mc.Count, i, this.ToString()));
                if (limitByImages && (int)totalFound >= limit)
                {
                    break;
                }
                // totalFound = totalFound + (uint)mc.Count;
            }
            LogHelper.Log(string.Format("SCRAPE: Found {0} total matches from this {1} object.", totalFound, this.ToString()));
        }
    }
}
