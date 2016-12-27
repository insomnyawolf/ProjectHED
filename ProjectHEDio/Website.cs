using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ProjectHEDio
{
    public abstract class WebsiteBase
    {
        protected static Queue<string> WebsiteImageLinks = new Queue<string>(); 

        protected Thread DownloadThread;

        public abstract int GetMaxPages(string[] arguments = null);

        // ReSharper disable once InconsistentNaming
        public abstract string FormatURL(string[] arguments = null, int pageNumber = 1);
    }
}
