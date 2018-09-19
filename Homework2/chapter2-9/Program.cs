using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter2_9
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[101];
            int i, j;
            int count = 0;
            for (i = 2; i < 101; i++) a[i] = 1;
            for (i = 2; i < 101; i++)
            {
                if (Convert.ToBoolean(a[i]))
                    //if (a[i]==1)
                    for (j = i + i; j < 101; j += i)
                        a[j] = 0;
            }
            for (i = 2; i < 101; i++)
                if (Convert.ToBoolean(a[i]))
                //if (a[i] == 1)
                {
                    count++;
                    System.Console.Write("{0} \t", i);
                }
            //System.Console.Write("count: {0} \n", count);
            Console.ReadKey(false);
        }
    }
}
