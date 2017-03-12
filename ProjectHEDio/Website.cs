using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using MetroFramework.Controls;

namespace ProjectHEDio
{
    public abstract class Website
    {
        private const int MaxSourceRetrievalRetries = 3;

        private static int TotalFileCount = 0;
        private static int TotalDownloadedCount = 0;
        private static int TotalLinkDuplicates = 0;
        private static int TotalFilenameDuplicates = 0;

        public static Queue<ScrapedFile> WebsiteFileLinks = new Queue<ScrapedFile>();

        public static List<Website> WebsiteList = new List<Website>();

        protected Thread ScrapeThread;

        public MetroPanel SourcePanel;

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

        public static int GetTotalFiles()
        {
            return TotalFileCount;
        }

        public static void IncrementDownloadedFileAmount()
        {
            TotalDownloadedCount++;
        }

        public static int GetDownloadedFiles()
        {
            return TotalDownloadedCount;
        }

        public static void IncrementLinkDuplicates()
        {
            TotalLinkDuplicates++;
        }

        public static int GetLinkDuplicates()
        {
            return TotalLinkDuplicates;
        }

        public static void IncrementFilenameDuplicates()
        {
            TotalFilenameDuplicates++;
        }

        public static int GetFilenameDuplicates()
        {
            return TotalFilenameDuplicates;
        }

        public static void Reset()
        {
            TotalFileCount = 0;
            TotalDownloadedCount = 0;
            WebsiteFileLinks.Clear();
            WebsiteList.Clear();
        }

        public static bool IsScraping()
        {
            if (WebsiteList.Count == 0)
            {
                return false;
            }
            foreach (Website w in WebsiteList)
            {
                if (w.ThreadIsAlive())
                {
                    return true;
                }
            }
            return false;
        }

        public static void AddToLinks(string link, int retries = 0)
        {
            TotalFileCount++;
            WebsiteFileLinks.Enqueue(new ScrapedFile(link, retries));
            LogHelper.Log(string.Format("FOUND: Link at \"{0}\" (r:{1})", link, retries));
        }

        public static void AddToLinks(string link, int width, int height, int retries = 0)
        {
            TotalFileCount++;
            WebsiteFileLinks.Enqueue(new ScrapedFile(link, width, height, retries));
            LogHelper.Log(string.Format("FOUND: Link at \"{0}\" (w:{1} h:{2}) (r:{3})", link, width, height, retries));
        }

        public void KillThread()
        {
            if (ScrapeThread != null)
            {
                if (ScrapeThread.IsAlive)
                {
                    ScrapeThread.Abort();
                }
            }
        }

        public bool ThreadIsAlive()
        {
            if (ScrapeThread == null)
            {
                return false;
            }
            return ScrapeThread.IsAlive;
        }

        public Website(MetroPanel sourcePanel)
        {
            // Add all websites that inherit from this class to a list.
            WebsiteList.Add(this);
            this.SourcePanel = sourcePanel;
        }

        public abstract void InitializeScrape(string[] arguments = null, int limit = 1, bool limitByImages = false);

        protected abstract int GetMaxPages(string[] arguments = null);

        protected abstract string FormatURL(string[] arguments = null, int pageNumber = 1);

        protected abstract void Scrape(string[] arguments = null, int limit = 1, bool limitByImages = false);
    }
}
