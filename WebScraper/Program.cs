using System;
using System.Net;
using System.Text;

namespace WebScraper
{
    class Program
    {
        //This WebScraper will make a call out to any url that I specify, and bring back
        // all of the text that is not in a tag of any kind.

        // This code can be easily modified to target specific tags. 
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            WebScraper();
        }

        static string WebScraper()
        {
            WebClient swClient = new WebClient();
            var response = swClient.DownloadData("https://www.dotnetconf.net/");
            string webData = Encoding.UTF8.GetString(response);

            //if its in a tag, i don't want it....
            bool inTag = false;
            StringBuilder sb = new StringBuilder();
            foreach (char t in webData)
            {
                if (t == '<')
                {
                    inTag = true;
                }
                if (!inTag)
                {
                    sb.Append(t);
                }
                if (t == '>')
                {
                    inTag = false;
                }
            }

            string myString = sb.ToString().Replace("\r\n", string.Empty);
            string newResult2 = myString.Replace("\t", string.Empty);
            return newResult2;
        }

        
    }
}
