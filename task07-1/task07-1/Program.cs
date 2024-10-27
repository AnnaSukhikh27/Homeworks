using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var k = GetNumber("k");

            if (IsStatementTrue(k))
                Console.WriteLine("Число не кратно ни 2, ни 3");
            else
                Console.WriteLine("Число кратно или 2, или 3, или обоим числам");

            Console.ReadKey();
        }

        static bool IsStatementTrue(int k)
        {
            return k % 2 != 0 && k % 3 != 0;
        }

        static int GetNumber(string numberName)
        {
            Console.WriteLine($"Введите число {numberName}");
            return int.Parse(Console.ReadLine());

        }
    }
}
