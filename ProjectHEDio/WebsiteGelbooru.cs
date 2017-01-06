using System;
using System.Threading;
using System.Text.RegularExpressions;
using MetroFramework.Controls;

namespace ProjectHEDio
{
    class WebsiteGelbooru : Website
    {
        public WebsiteGelbooru(MetroPanel sourcePanel) : base(sourcePanel)
        {

        }

        public override void InitializeScrape(string[] arguments = null, int totalPages = 1)
        {
            ScrapeThread = new Thread(() => Scrape(arguments, totalPages));
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
                        return (int)((result / 42) + 1);
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
            // We'll use the API for this :3c
            return string.Format("http://gelbooru.com/index.php?page=dapi&s=post&q=index&limit=42&pid={0}&tags={1}", (pageNumber - 1), GetTagList(arguments));
        }

        protected override void Scrape(string[] arguments = null, int totalPages = 1)
        {
            int pages = GetMaxPages(arguments);
            if (pages < 1)
            {
                return;
            }
            if (totalPages < pages)
            {
                pages = totalPages;
            }
            ulong totalFound = 0;
            for (int i = 1; i <= pages; i++)
            {
                string source = GetSource(FormatURL(arguments, i));
                // Images can be retrieved from the XML file.
                // <post height="(?<Height>\d+)" ?(?:[^\"]+"){2}[^f]?file_url="(?<Link>[^\"]+)"
                // id="\d+" width="(?<Width>\d+)
                // <post[^>]+\/>
                string postPattern = "<post[^>]+\\/>";
                MatchCollection mc = Regex.Matches(source, postPattern);
                foreach (Match m in mc)
                {
                    string postString = m.Value;
                    string mainPattern = "<post height=\"(?<Height>\\d+)\" ?(?:[^\\\"]+\"){2}[^f]?file_url=\"(?<Link>[^\\\"]+)";
                    string widthPattern = "id=\"\\d+\" width=\"(?<Width>\\d+)";

                    string link = Regex.Match(postString, postPattern).Groups["Link"].Value;
                    int width = -1;
                    int height = -1;
                    string widthCaptured = Regex.Match(postString, widthPattern).Groups["Width"].Value;
                    string heightCaptured = Regex.Match(postString, mainPattern).Groups["Height"].Value;
                    if (int.TryParse(widthCaptured, out width) && int.TryParse(heightCaptured, out height))
                    {
                        AddToLinks(link, width, height);
                    }
                    else
                    {
                        AddToLinks(link);
                    }
                }
                LogHelper.Log(string.Format("PAGE: Found {0} matches from page {1} of this {2} object.", mc.Count, i, this.ToString()));
                totalFound = totalFound + (uint)mc.Count;
            }
            LogHelper.Log(string.Format("SCRAPE: Found {0} total matches from this {1} object.", totalFound, this.ToString()));
        }
    }
}
