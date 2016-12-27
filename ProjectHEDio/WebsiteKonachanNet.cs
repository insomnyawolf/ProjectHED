using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectHEDio
{
    class WebsiteKonachanNet : WebsiteBase
    {
        public WebsiteKonachanNet()
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
            
        }

        protected override string FormatURL(string[] arguments = null, int pageNumber = 1)
        {
            
        }

        protected override void Scrape(string[] arguments = null, int totalPages = 1)
        {
            
        }
    }
}
