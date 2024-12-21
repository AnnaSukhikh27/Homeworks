using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace task11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст");
            string input = Console.ReadLine();
            string cleanedInput = Regex.Replace(input, @"[^\w\s]", "");

            string[] words = cleanedInput.Split(' ');

            string[] capitalizeLetters = CapitalizeLetters(words);

            string[] reversedWords = ReverseWords(words);

            Console.WriteLine("Слова из строки в обратном порядке:");
            foreach (string word in reversedWords)
            {
                Console.WriteLine(word);
            }

            double averageLength = CalculateAverageWordLength(words);
            Console.WriteLine($"Среднее арифметическое длины слов: {averageLength}");

            Console.ReadKey(); 
        }

        static string[] CapitalizeLetters(string[] words) 
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrEmpty(words[i]))
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
                }
            }
            return words;
        }
        static double CalculateAverageWordLength(string[] words)
        {
            int totalLength = 0; 
            foreach (string word in words)
            {
                totalLength += word.Length;
            }

            if (words.Length > 0)
            {
                return (double)totalLength / words.Length;
            }
            else
            {
                return 0;
            }
            
        }

        static string[] ReverseWords(string[] words)
        {
            string[] reversedWords = new string[words.Length]; 
            for (int i = 0; i < words.Length; i++)
            {
                char[] charArray = words[i].ToCharArray(); 
                Array.Reverse(charArray); 
                reversedWords[i] = new string(charArray); 
            }
            return reversedWords; 
        }
    }
}
