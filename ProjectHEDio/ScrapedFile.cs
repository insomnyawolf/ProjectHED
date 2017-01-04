using System;

namespace ProjectHEDio
{
    public class ScrapedFile
    {
        private string Link;
        private int Retries = 0;

        public ScrapedFile()
        {
            throw new NotSupportedException();
        }

        public ScrapedFile(string link)
        {
            this.Link = link;
        }

        public ScrapedFile(string link, int retries)
        {
            this.Link = link;
            this.Retries = retries;
        }
    }
}
