using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task07_3_fixed_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите позицию слона");
            var bishopPosition = Console.ReadLine();

            if (IsPositionIncorrect(bishopPosition))
            {
                Console.WriteLine("Некорректная позиция фигуры");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Введите позицию хода слона");
            var bishopMove = Console.ReadLine();

            if (!IsBishopMoveCorrect(bishopPosition, bishopMove))
            {
                Console.WriteLine("Слон не может так сходить");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Введите позицию ладьи");
            var rookPosition = Console.ReadLine();

            if (IsPositionIncorrect(rookPosition))
            {
                Console.WriteLine("Некорректная позиция фигуры");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Введите позицию хода ладьи");
            var rookMove = Console.ReadLine();

            if (!IsRookMoveCorrect(rookPosition, rookMove))
            {
                Console.WriteLine("Ладья не может так сходить");
                Console.ReadKey();
                return;
            }


            if (IsBishopUnderAttackDuringRookMove(bishopPosition, rookPosition, rookMove))
            {
                Console.WriteLine("Слон находится под боем после хода ладьи");
            }
            else
            {
                Console.WriteLine("Ход возможен!");
            }

            Console.ReadKey();
        }

        static bool IsPositionIncorrect(string position)
        {
            if (position.Length != 2)
                return true;

            char column = position[0];
            char row = position[1];

            return !(column >= 'a' && column <= 'h' && row >= '1' && row <= '8');
        }

        static bool IsBishopMoveCorrect(string bishopPosition, string move)
        {
            int bpColumn, bpRow, mColumn, mRow;

            DecodePosition(bishopPosition, out bpColumn, out bpRow);
            DecodePosition(move, out mColumn, out mRow);

            return Math.Abs(bpColumn - mColumn) == Math.Abs(bpRow - mRow);
        }

        static bool IsRookMoveCorrect(string rookPosition, string move)
        {
            int rpColumn, rpRow, mColumn, mRow;

            DecodePosition(rookPosition, out rpColumn, out rpRow);
            DecodePosition(move, out mColumn, out mRow);

            return rpColumn == mColumn || rpRow == mRow;
        }

        static bool IsBishopUnderAttackDuringRookMove(string bishopPosition, string rookPosition, string rookMove)
        {
            int bpColumn, bpRow, rpColumn, rpRow, rmColumn, rmRow;

            DecodePosition(bishopPosition, out bpColumn, out bpRow);
            DecodePosition(rookPosition, out rpColumn, out rpRow);
            DecodePosition(rookMove, out rmColumn, out rmRow);

            bool isRookPathCrossingBishop = (rpColumn == rmColumn && bpColumn == rpColumn) || (rpRow == rmRow && bpRow == rpRow);

            return isRookPathCrossingBishop;
        }

        static void DecodePosition(string position, out int column, out int row)
        {
            column = (int)position[0] - 0x60; 
            row = int.Parse(position[1].ToString()); 
        }
    }
}
