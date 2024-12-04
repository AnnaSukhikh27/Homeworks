using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите натуральное число");

            int number;

            if (!int.TryParse(Console.ReadLine(), out number) || number < 1)
            {
                Console.WriteLine("Ошибка ввода");
                Console.ReadKey();
                return;
            }

            int minDigit = 9;
            int minPosition = 0;
            int position = 1;
            int temp = number;

            while (temp > 0)
            {
                int currentDigit = temp % 10;
                if (currentDigit < minDigit) 
                {
                    minDigit = currentDigit;
                    minPosition = position;
                }

                temp /= 10;
                position++;

            }


            Console.WriteLine($"Минимальная цифра числа {number} стоит на {minPosition} месте, если считать справа налево");

            Console.ReadKey();
        }
    }
}
