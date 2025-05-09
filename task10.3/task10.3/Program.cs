using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace task10._3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int number;
            int maxNumber = int.MinValue;

            do
            {
                if (!TryInputNumber("Введите очередной член последовательности", out number))
                {
                    Console.ReadKey();
                    return;
                }

                if (number != 0)
                {
                    if (number > maxNumber)
                    {
                        maxNumber = number;
                    }
                }

            } while (number != 0);

            Console.WriteLine($"Максимальное число в последовательности {maxNumber}");

            Console.ReadKey();
        }
        static bool TryInputNumber(string message, out int number)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();

            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Ошибка ввода");
                return false;
            }

            return true;
        }
    }
}
