using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;

            if (!TryInputNumber("Введите количество чисел: ", out n))
            {
                Console.ReadKey();
                return;
            }

            double sumOfSquares = 0;

            for (int i = 1; i <= n; i++)
            {
                int k;
                if (!TryInputNumber($"Введите число k{i}: ", out k))
                {
                    Console.ReadKey();
                    return;
                }
                sumOfSquares += k * k;
            }

            double result = Math.Sqrt(sumOfSquares);
            Console.WriteLine("Результат: " + result);
            Console.ReadKey();
        }   
        static bool TryInputNumber(string message, out int number) 
        { 
            Console.WriteLine(message);
            var input = Console.ReadLine();
            if (!int.TryParse(input, out number) || number < 0) 
            {
                Console.WriteLine("Ошибка ввода");
                return false;
            }
            return true;
        }

    }
}
