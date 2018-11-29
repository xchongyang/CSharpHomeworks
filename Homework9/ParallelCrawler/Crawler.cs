using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParallelCrawler
{
    class Crawler
    {
        Stopwatch stopWatch = new Stopwatch();
        private int count = 0;
        private int max = 100;
        public List<String> complated = new List<string>();
        public Queue<String> pending = new Queue<string>();


        public void Start(String url, int max)
        {
            stopWatch.Start();
            this.count = 0;
            this.max = max;
            pending.Enqueue(url);
            while (pending.Count > 0 && count < max)
            {
                String url2 = pending.Dequeue();
                HashSet<String> newUrls = DownloadAndParse(url2);
                complated.Add(url2);
                foreach (String u in newUrls)
                {
                    if (pending.Contains(u) || complated.Contains(u)) continue;
                    pending.Enqueue(u);
                }
            }
            stopWatch.Stop();
            Console.WriteLine("time cost:" + stopWatch.ElapsedMilliseconds);
        }

        public HashSet<String> DownloadAndParse(String url)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            try
            {
                Console.WriteLine($"Downlonding {url}");
                String page = client.DownloadString(url);
                File.WriteAllText(count.ToString(), page, Encoding.UTF8);
                count++;
                Console.WriteLine($"Parsing {url}");
                HashSet<String> urls = Parse(page);
                return urls;
            }
            catch
            {
                return new HashSet<String>();
            }
        }

        private HashSet<string> Parse(string page)
        {

            HashSet<String> urls = new HashSet<string>();
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";

            MatchCollection matches = new Regex(strRef).Matches(page);
            foreach (Match match in matches)
            {
                String url = match.Value.Substring(match.Value.IndexOf("=") + 1)
                  .Trim('"', '\"', '#', ',', '>');
                if (url.Length == 0) continue;
                urls.Add(url);
            }
            return urls;
        }


    }
}
