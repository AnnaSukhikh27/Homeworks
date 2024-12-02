using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double R = 6350;
            double H;
            for (double d = 1; d <= 10; d++)
            {
                H = Math.Sqrt((R + d) * (R + d) - (R * R));

                Console.WriteLine("При h = " + d + " Расстояние до линии горизонта = " + H);
            }

            Console.ReadKey();
        }


    }
}
