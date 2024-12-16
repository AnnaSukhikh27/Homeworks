using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество лет (n): ");
            int n = GetNaturalNumber();
            if (n == 0) return;

            Console.Write("Введите процентную ставку (x): ");
            double x = GetPositiveDouble();
            if(x == 0) return;

            Console.Write("Введите сумму вклада в месяц (m): ");
            double m = GetPositiveDouble();
            if (m == 0) return;

            int totalMonths = n * 12;
            double monthlyRate = x / 12 / 100; 
            double balance = 0;

            Console.WriteLine("Таблица суммы на депозите:\n");
            Console.WriteLine("Месяц \t Сумма на депозите");

            for (int month = 1; month <= totalMonths; month++)
            {
                balance += m; 
                balance += balance * monthlyRate; 

                Console.WriteLine($"{month}\t{balance:F2}");
            }

            Console.ReadKey();
        }

        static int GetNaturalNumber()
        {
            int number;
            if (!int.TryParse(Console.ReadLine(), out number) || number < 1)
            {
                Console.Write("Ошибка ввода");
                Console.ReadKey();
                return 0;
            }
            return number;

        }

        static double GetPositiveDouble()
        {
            double number;
            if (!double.TryParse(Console.ReadLine(), out number) || number < 1)
            {
                Console.Write("Ошибка ввода");
                Console.ReadKey();
                return 0;
            }
            return number;
            
        }


    }
    
}
