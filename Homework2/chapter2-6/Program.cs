using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\n请输入一个数：");
            string s = Console.ReadLine();
            int a = int.Parse(s);
            if (a <= 1)
                Console.WriteLine("请输入大于1的整数！");
            else
                Console.WriteLine("您输入的数的所有素数因子为：");
            for (int m = 2; m <= a; m++)
                if (a % m == 0)
                    Console.WriteLine(m);
            Console.ReadKey(false);
        }
    }
}
