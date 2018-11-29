using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            String startUrl = "http://www.cnblogs.com/dstang2000/";
            Crawler crawler1 = new Crawler();
            crawler1.Start(startUrl, 20);
            ParallerCrawler crawler2 = new ParallerCrawler();
            //crawler2.Start(startUrl,20);
            Console.ReadKey();
        }
    }
}
