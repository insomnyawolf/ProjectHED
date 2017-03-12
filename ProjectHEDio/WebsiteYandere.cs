using System;
using System.Threading;
using System.Text.RegularExpressions;
using MetroFramework.Controls;

namespace ProjectHEDio
{
    class WebsiteYandere : Website
    {
        public WebsiteYandere(MetroPanel sourcePanel) : base(sourcePanel)
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

            if (source.Contains("Nobody here but us chickens!"))
            {
                return 0;
            }
            if (!source.Contains("Next Page"))
            {
                return 1;
            }

            string pattern = "page=(?<LastPage>\\d+)[^\"]+\" ?rel=\"last\"";
            string match = Regex.Match(source, pattern).Groups["LastPage"].Value;
            int result = -1;
            if (int.TryParse(match, out result))
            {
                return result;
            }
            return -1;
        }

        protected override string FormatURL(string[] arguments = null, int pageNumber = 1)
        {
            return string.Format("http://yande.re/post?page={0}&tags={1}", pageNumber, GetTagList(arguments));
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
                // Images can be retrieved from the Javascript.
                // Post\.register\({(?:[^,]+,){13}\"file_url\":\"(?<Link>[^\"]+)
                string pattern = "Post\\.register\\({(?:[^,]+,){13}\\\"file_url\\\":\\\"(?<Link>[^\\\"]+)";
                MatchCollection mc = Regex.Matches(source, pattern);
                foreach (Match m in mc)
                {
                    if (limitByImages)
                    {
                        if ((int)totalFound < limit)
                        {
                            AddToLinks(m.Groups["Link"].Value);
                            totalFound++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        AddToLinks(m.Groups["Link"].Value);
                        totalFound++;
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
