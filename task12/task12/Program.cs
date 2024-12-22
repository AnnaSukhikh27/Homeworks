using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число m от 5 до 20");
            int m;

            if (!TryInputNumber(out m))
            {
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Введите целое число n от 5 до 20");
            int n;

            if (!TryInputNumber(out n))
            {
                Console.ReadKey();
                return;
            }

            if (m < 5 || m > 20 || n < 5 || n > 20)
            {
                Console.WriteLine("Числа не удовлетворяют неравенству 5 <= m,n <= 20");
                Console.ReadKey();
                return;
            }

            Console.WriteLine();

            var matrix = new int[m, n];

            var rnd = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = rnd.Next(100);

            PrintMatrix(matrix);

            Console.WriteLine();
            Console.WriteLine("Введите число, на которое должен делиться элемент матрицы:");

            if (!TryInputNumber(out int divisor) || divisor == 0)
            {
                Console.WriteLine("Ошибка ввода");
                Console.ReadKey();
                return;
            }
            
            FindDividedNumber(matrix, divisor);

            Console.WriteLine();
            FindEvenColumnElements(matrix);

            Console.WriteLine();
            Console.ReadKey();
        }
        static bool TryInputNumber(out int number)
        {
            number = 0;
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("Ошибка ввода");
                return false;
            }

            number = n;
            return true;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j],2} ");

                Console.WriteLine();
            }
        }

        static void FindDividedNumber(int[,] matrix, int divisor)
        {
            bool found = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] % divisor == 0)
                    {
                        Console.WriteLine($"Элемент {matrix[i, j]} делится на {divisor} без остатка. Индексы: строка {i}, столбец {j}");
                        found = true;
                    }
                }
            }

            if (found == false)
            {
                Console.WriteLine($"В массиве нет элементов, которые делятся на {divisor} без остатка.");
            }
        }

        static void FindEvenColumnElements(int[,] matrix) 
        {
            Console.WriteLine("Произведения четных элементов для каждого столбца:");

            for (int j = 0; j < matrix.GetLength(1); j++) 
            {
                int product = 1; 
                bool evenNumber = false; 

                for (int i = 0; i < matrix.GetLength(0); i++) 
                {
                    if (matrix[i, j] % 2 == 0) 
                    {
                        product *= matrix[i, j];
                        evenNumber = true;
                    }
                }

                if (evenNumber)
                {
                    Console.WriteLine($"Столбец {j}: Произведение = {product}");
                }
                else
                {
                    Console.WriteLine($"Столбец {j}: Нет четных элементов");
                }
            }
        }
    }
}
