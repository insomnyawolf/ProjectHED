using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;

namespace ProjectHEDio
{
    public abstract class WebsiteBase
    {
        protected static string GetSource(string url)
        {
            string source = string.Empty;
            try
            {
                using (WebClient wc = new WebClient())
                {
                    source = wc.DownloadString(url);
                }
            }
            catch (WebException)
            {
                LogHelper.Log("Unable to download source (" + url + ").", LogHelper.LogType.Error);
            }
            return source;
        }

        protected static string GetTagList(string[] arguments)
        {
            if (arguments == null)
            {
                return string.Empty;
            }
            if (arguments.Length < 1)
            {
                return string.Empty;
            }
            string result = string.Empty;
            for (int i = 0; i < arguments.Length; i++)
            {
                result += arguments[i].Replace("+", "") + (i == arguments.Length - 1 ? "" : "+");
            }
            return result;
        }

        protected static Queue<string> WebsiteImageLinks = new Queue<string>();

        // For every object instantiated that derives from this class, is there an individual thread for each object?
        protected Thread ScrapeThread;

        public abstract bool ThreadIsAlive();

        public abstract void InitializeScrape(string[] arguments = null, int totalPages = 1);

        protected abstract int GetMaxPages(string[] arguments = null);

        protected abstract string FormatURL(string[] arguments = null, int pageNumber = 1);

        protected abstract void Scrape(string[] arguments = null, int totalPages = 1);
    }
}
