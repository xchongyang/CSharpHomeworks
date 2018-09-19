using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chapter1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("NumbOne=");
            string NumbOne = Console.ReadLine();
            Console.Write("NumbTwo=");
            string NumbTwo = Console.ReadLine();
            double NumOne = Convert.ToDouble(NumbOne);
            double NumTwo = Convert.ToDouble(NumbTwo);
            Console.WriteLine("NumbOne*NumbTwo=" + (NumOne * NumTwo));
            Console.ReadKey();
        }
    }
}
