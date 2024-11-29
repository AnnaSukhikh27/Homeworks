using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите четырехзначное число");

            var number = int.Parse(Console.ReadLine());

            var thousands = number / 1000;
            var hundreds = (number / 100) % 10;
            var tens = (number / 10) % 10;
            var units = number % 10;

            var newNumber = thousands * 1000 + hundreds * 10 + tens * 100 + units;

            Console.WriteLine(newNumber);

            Console.ReadKey();
        }
    }
}
