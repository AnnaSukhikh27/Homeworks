using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите сторону ромба");
            var a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите угол смежных сторон ромба(в градусах)");
            var alpha = double.Parse(Console.ReadLine()) * Math.PI / 180;
            var area = Math.Pow(a, 2) * Math.Sin(alpha);
            var p = a * 4;

            Console.WriteLine("Площадь ромба = " + area);
            Console.WriteLine("Периметр ромба = " + p);

            Console.ReadKey();
        }
    }
}
