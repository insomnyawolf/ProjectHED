using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;

namespace ProjectHEDio
{
    class WebsiteYandere : WebsiteBase
    {
        public override void InitializeScrape(string[] arguments = null, int totalPages = 1)
        {
            ScrapeThread = new Thread(() => Scrape(arguments, totalPages));
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

            string pattern = "page=(\\d+)[^\"]+\" ?rel=\"last\"";
            string match = Regex.Match(source, pattern).Groups[1].Value;
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
            for (int i = 1; i <= pages; i++)
            {
                string source = GetSource(FormatURL(arguments, i));
                // Images can be retrieved from the Javascript.
                // We can most likely improve this regular expression, or use a different method.
                // Post\.register\({[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,\"file_ext\":\"([^\"]+)\",\"file_url\":\"([^\"]+)\"
                string reallyBadPattern = "Post\\.register\\({[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,[^,]+,\\\"file_ext\\\":\\\"([^\\\"]+)\\\",\\\"file_url\\\":\\\"([^\\\"]+)\\\"";
                // Group 1: File extension. We could use this later.
                // Group 2: Link to image.
                MatchCollection mc = Regex.Matches(source, reallyBadPattern);
                foreach (Match m in mc)
                {
                    WebsiteImageLinks.Enqueue(m.Groups[2].Value);
                }
            }
        }
    }
}
