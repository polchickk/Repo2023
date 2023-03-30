using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Generics
{
    internal static class Program
    {
        static void Main(string[] args) 
        { 
            var integers = new[] {1,2,3,4,5};
            var doubles = new[] { 1.5, -2.0, 3 };

            PrintNumbers<int>(integers);
            Console.WriteLine( );
            PrintNumbers<double>(doubles);

            var john = new Person<string> { Name = "John", Description = "Text" };
            var kate = new Person<int> { Name = "Kate", Description = 1 };
            Console.ReadKey();
        }

        static void PrintNumbers<T>(T[] values)
        {
            foreach(var value in values) 
                Console.Write($"{value} ");
        }
    }
}