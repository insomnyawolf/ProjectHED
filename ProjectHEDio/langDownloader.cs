using System;
using System.IO;
using System.Net;

namespace ProjectHEDio
{
    class lang
    {

        internal static void download()
        {
            string url, path;

            Directory.CreateDirectory("lang");
            path = Directory.GetCurrentDirectory() + "\\lang\\";
            string[] languajes = { "english", "spanish" };
            foreach(string lang in languajes)
            {
                url = "http://phed.rubend447.fluctis.com/" + lang + ".ini";
                WebClient client = new WebClient();
                client.DownloadFileAsync(new Uri(url), path + lang + ".ini");
            }
        }
    }
}
