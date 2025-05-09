using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите площадь прямоугольника");
            if (!int.TryParse(Console.ReadLine(), out int n) || n < 1)
            {
                Console.WriteLine("Ошибка ввода");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Стороны прямоугольника с площадью {n}:");
            for (int a = 1; a * a <= n; a++) 
            {
                if (n % a == 0) 
                {
                    int b = n / a;
                    Console.WriteLine($"{a} и {b}");
                }
            }
            
            Console.ReadKey();
        }

       
    }
}
