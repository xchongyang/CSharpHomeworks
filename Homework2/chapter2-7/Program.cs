using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter2_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = new int[10];
            Console.WriteLine("请输入10个整数：");
            for (int i = 0; i < 10; i++)
            {
                string s = Console.ReadLine();
                int x = int.Parse(s);
                num[i] = x;
            }
            int max = num[0];
            for (int n = 1; n < 10; n++)
            {
                if (max < num[n])
                    max = num[n];
            }
            int min = num[0];
            for (int a =1;a<10;a++)
            {
                if (min > num[a])
                    min = num[a];
            }
            int all = 0;
            for (int m = 0; m < 10; m++)
                all += num[m];
            double average = all / 10.0;
            string temp = string.Format("该数组的最大值为{0}，最小值为{1}，平均值为{2:F4}，和为{3}",max,min,average,all);
            Console.WriteLine(temp);
            Console.ReadKey(false);
        }
    }
}
