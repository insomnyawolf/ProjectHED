using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectHEDio
{
    static class Program
    {
        private static List<System.Net.WebClient> WebClientList = new List<System.Net.WebClient>();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LogHelper.ClearLogFile();

            string[] tags = { "kaname_madoka" };
            WebsiteKonachanNet wkc = new WebsiteKonachanNet();
            wkc.InitializeScrape(tags, Int32.MaxValue);
            while (wkc.ThreadIsAlive())
            {
                while (WebsiteBase.WebsiteImageLinks.Count > 0)
                {
                    string url = WebsiteBase.WebsiteImageLinks.Dequeue();
                    try
                    {
                        Uri uri = new Uri(url);
                        WebClientList.Add(new System.Net.WebClient());
                        if (!System.IO.Directory.Exists(@"C:\Users\moech\Desktop" + "\\test"))
                        {
                            System.IO.Directory.CreateDirectory(@"C:\Users\moech\Desktop" + "\\test");
                        }
                        string filename = Uri.UnescapeDataString(url.Split('/')[url.Split('/').Length - 1]).Replace("Konachan.com - ", "");
                        WebClientList.Last().DownloadFileAsync(uri, @"C:\Users\moech\Desktop" + "\\test\\" + filename);
                        LogHelper.Log("Started download: " + filename);
                    }
                    catch (Exception)
                    {
                        LogHelper.Log("Couldn't download " + url + "!", LogHelper.LogType.Error);
                    }
                }
            }
            bool isDone = false;
            while (!isDone)
            {
                isDone = true;
                foreach (System.Net.WebClient wc in WebClientList)
                {
                    if (wc.IsBusy)
                    {
                        isDone = false;
                        break;
                    }
                }
            }
            foreach (System.Net.WebClient wc in WebClientList)
            {
                wc.Dispose();
            }
            LogHelper.Log("Done!");
            MessageBox.Show("done");
        }
    }
}
