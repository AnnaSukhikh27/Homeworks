using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var x = CountExp(2, 3) + CountExp(5, 7) + CountExp(4, 6);
            Console.WriteLine ($"x = {x:F3}");

            Console.ReadKey();
        }

        static double CountExp(double a, double b) {
            return (Math.Exp(a) - Math.Exp(-a)) / (Math.Exp (b) + Math.Exp(-b));
        }
    }
}
