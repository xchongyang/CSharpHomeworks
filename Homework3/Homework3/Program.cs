using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Homework3
{
    class Program
    {
        public abstract class Graph
        {
            public abstract string GraphShow();
        }
        class 三角形 : Graph
        {
            public override string GraphShow()
            {
                Console.Write("三角形的底边为");
                double 三角形的底边 = Convert.ToDouble(Console.ReadLine());
                Console.Write("三角形的高为");
                double 三角形的高 = Convert.ToDouble(Console.ReadLine());
                double area = 三角形的底边 * 三角形的高 / 2;
                string temp = string.Format("三角形的面积为{0}", area);
                return (temp);
            }
        }
        class 圆形 : Graph
        {
            public override string GraphShow()
            {
                Console.Write("圆形的半径为");
                double 圆形的半径 = Convert.ToDouble(Console.ReadLine());
                double area = 圆形的半径 * 圆形的半径 * Math.PI;
                string temp = string.Format("圆形的面积为{0}", area);
                return (temp);
            }
        }
        class 正方形 : Graph
        {
            public override string GraphShow()
            {
                Console.Write("正方形的边长为");
                double 边长 = Convert.ToDouble(Console.ReadLine());
                double area = 边长 * 边长;
                string temp = string.Format("正方形的面积为{0}", area);
                return (temp);
            }
        }
        class 长方形 : Graph
        {
            public override string GraphShow()
            {
                Console.Write("长方形的长为");
                double 长 = Convert.ToDouble(Console.ReadLine());
                Console.Write("长方形的宽为");
                double 宽 = Convert.ToDouble(Console.ReadLine());
                double area = 长 * 宽;
                string temp = string.Format("长方形的面积为{0}", area);
                return (temp);
            }
        }
        public class GraphFactory
        {
            public static Graph createGraph(string type)
            {
                Graph gra = null;
                switch (type)
                {
                    case "三角形":
                        gra = new 三角形();
                        break;
                    case "圆形":
                        gra = new 圆形();
                        break;
                    case "正方形":
                        gra = new 正方形();
                        break;
                    case "长方形":
                        gra = new 长方形();
                        break;
                }
                return gra;
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Graph 三角形 = GraphFactory.createGraph("三角形");
                Graph 圆形 = GraphFactory.createGraph("圆形");
                Graph 正方形 = GraphFactory.createGraph("正方形");
                Graph 长方形 = GraphFactory.createGraph("长方形");
                if (三角形 != null)
                {
                    Console.WriteLine(三角形.GraphShow());
                }
                if (圆形 != null)
                {
                    Console.WriteLine(圆形.GraphShow());
                }
                if (正方形 != null)
                {
                    Console.WriteLine(正方形.GraphShow());
                }
                if (长方形 != null)
                {
                    Console.WriteLine(长方形.GraphShow());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("您输入有错：" + ex.Message);
            }
            Console.ReadKey(false);
        }
    }
}
