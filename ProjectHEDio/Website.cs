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
        private const int MaxSourceRetrievalRetries = 3;
        private static int TotalFileCount = 0;

        protected static string GetSource(string url)
        {
            LogHelper.Log("Downloading source (" + url + ")...");
            string source = string.Empty;
            try
            {
                using (WebClient wc = new WebClient())
                {
                    source = wc.DownloadString(url);
                    LogHelper.Log("Downloaded source (" + url + ").");
                }
            }
            catch (WebException)
            {
                LogHelper.Log("Unable to download source (" + url + ").", LogHelper.LogType.Error);
                for (int tries = 1; tries <= MaxSourceRetrievalRetries; tries++)
                {
                    LogHelper.Log(string.Format("Retrying source download ({0}) [retry #{1}]...", url, tries), LogHelper.LogType.Warning);
                    try
                    {
                        using (WebClient wc = new WebClient())
                        {
                            source = wc.DownloadString(url);
                            LogHelper.Log(string.Format("Downloaded source ({0}) after {1} tr{2}.", url, tries, (tries == 1 ? "y" : "ies")));
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        LogHelper.Log("Unable to download source (" + url + ").", LogHelper.LogType.Error);
                    }
                }
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

        public static Queue<ScrapedFile> WebsiteFileLinks = new Queue<ScrapedFile>();

        public void Reset()
        {
            WebsiteFileLinks.Clear();
        }

        protected static void AddToLinks(string link, int retries = 0)
        {
            TotalFileCount++;
            WebsiteFileLinks.Enqueue(new ScrapedFile(link, retries));
        }

        protected Thread ScrapeThread;

        public bool ThreadIsAlive()
        {
            return ScrapeThread.IsAlive;
        }

        public static List<WebsiteBase> WebsiteList = new List<WebsiteBase>();

        public WebsiteBase()
        {
            // Add all websites that inherit from this class to a list.
            WebsiteList.Add(this);
        }

        public abstract void InitializeScrape(string[] arguments = null, int totalPages = 1);

        protected abstract int GetMaxPages(string[] arguments = null);

        protected abstract string FormatURL(string[] arguments = null, int pageNumber = 1);

        protected abstract void Scrape(string[] arguments = null, int totalPages = 1);
    }
}
