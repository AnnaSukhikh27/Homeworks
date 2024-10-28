using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите позицию белого слона");
            var whitePosition = Console.ReadLine();

            int whiteRow, whiteColumn;

            DecodePosition(whitePosition, out whiteRow, out whiteColumn);
            Console.WriteLine($"({whiteRow}; {whiteColumn})");

            Console.WriteLine("Введите позицию черной ладьи");
            var blackPawnPosition = Console.ReadLine();

            int blackRow, blackColumn;

            DecodePosition(blackPawnPosition, out blackRow, out blackColumn);
            Console.WriteLine($"({blackRow}; {blackColumn})");

            var x1 = whiteRow;
            var y1 = whiteColumn;
            var x2 = blackRow;
            var y2 = blackColumn;

            if (SamePosition(x1, y1, x2, y2))
                Console.WriteLine("Некорректно расположены фигуры. Поменяйте значение");
            else
            {
                Console.WriteLine("На какую клетку встанет слон?");
                var ElephantPosition = Console.ReadLine();

                int ElephantRow, ElephantColumn;

                DecodePosition(ElephantPosition, out ElephantRow, out ElephantColumn);


                if (PossiblePosition(ElephantRow, ElephantColumn, blackRow, blackColumn))
                    Console.WriteLine("Ход возможен. Под бой ладьи не попадете");
                else
                    Console.WriteLine("Ход невозможен. Попадете под бой ладьи");
            }
                


            Console.ReadKey();
        }
        static void DecodePosition(string position, out int x, out int y)
        {
            x = int.Parse(position[1].ToString());
            y = (int)position[0] - 0x60;
        }

        static bool SamePosition(int x1, int y1, int x2, int y2)
        {
            return x1 == x2 && y1 ==y2;
        }

        static bool PossiblePosition (int ElephantRow, int ElephantColumn, int blackRow, int blackColumn)
        {
            return !(blackRow == ElephantRow || blackColumn == ElephantColumn);
        }
    }
}
