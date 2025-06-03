using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Perfomance;

namespace PerfomanceApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hamlet = new TheaterPerfomance(
                "Гамлет",
                new TimeSpan(2, 30, 0),
                new DateTime(2025, 3, 5, 19, 0, 0),
                PerfomanceType.Premiere
            );

            hamlet.Coefficient = 0.25;
            hamlet.Description = "Трагическая история о Гамлете, принце датском";

            string[] info = hamlet.GetInfo();
            foreach (var line in info)
            {
                Console.WriteLine(line);

            }

            Console.ReadKey();

        }
    }
}
