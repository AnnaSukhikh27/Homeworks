using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите от 3 до 9 простых чисел, оканчивающихся на 7 и разделённых пробелами:");
            var input = Console.ReadLine();
            var numbers = ParseInputNumbers(input);

            if (numbers == null || numbers.Count == 0) return;

            Console.WriteLine($"F({numbers.Count}) = {ComputeF(numbers.Count, numbers)}");
            Console.ReadKey();

        }

        static bool IsPrime(int num)
        {
            if (num <= 1) return false;

            int root = (int)Math.Sqrt(num);
            if (root * root == num) return false;

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }

        static List<int> ParseInputNumbers(string input)
        {
            var parts = input.Split(new[] { ' ' });

            var numbers = new List<int>();
            foreach (var part in parts)
            {
                if (int.TryParse(part, out int num) && num > 0)
                {
                    if (IsPrime(num) && num % 10 == 7)
                    {
                        numbers.Add(num);
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка ввода: число {num} должно быть простым и заканчиваться на 7.");
                        Console.ReadKey();
                        return null;
                    }
                }

                else
                {
                    Console.WriteLine($"Ошибка ввода: {part} не является числом.");
                    Console.ReadKey();
                    return null;
                }
            }

            return numbers;
        }

        static List<int> GenerateS(int k, List<int> userNumbers)
        {
            var primes = new List<int> { 2, 5 };
            int count = 0;

            foreach (var num in userNumbers)
            {
                primes.Add(num);
                count++;

                if (count == k)
                {
                    break;
                }

            }

            return primes;
        }

        static bool IsRaffaNumber(int number, List<int> s)
        {
            foreach (var prime in s)
            {
                if (number % prime == 0) return false;
            }
            return true;
        }

        static int ComputeF(int k, List<int> userNumbers)
        {
            var s = GenerateS(k, userNumbers);
            int nK = 1;
            foreach (var val in s)
            {
                nK *= val;
            }

            int sum = 0;

            for (int i = 7; i < nK; i += 10)
            {
                if (IsRaffaNumber(i, s))
                {
                    sum = (sum + i) % 1000000007;
                }
            }

            return sum;
        }


    }

}

