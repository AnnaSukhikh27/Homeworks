using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task06_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "гардероб";
            Console.WriteLine($"Из слова \"{s}\" получили");


            var word1 =
                ReverseString(s.Remove(4, 4)) + 
                s.Remove(2) 
                .Remove(0,1); 

            Console.WriteLine(word1);


            var word2 =
                ReverseString(s.Remove(5, 2)) 
                .Remove(4) + 
                ReverseString(s.Remove(7)) 
                .Remove(1); 

            Console.WriteLine(word2);  


            Console.ReadKey();
        }

        static string ReverseString(string s)
        {
            return new string(s.Reverse().ToArray());
        }
    }
}
