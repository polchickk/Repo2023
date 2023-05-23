using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { -5, 0, 15, 7, 25, 10, 91, 85 };
            int index = 2;

            static int[] GetPositiveOddTwoDigitNumbers(int[] array, int index) => array
                .Skip(index)
                .Where(n => n > 0 && n % 2 != 0 && n >= 10 && n <= 99)
                .Distinct()
                .OrderBy(n => n)
                .ToArray();
           
            static void PrintIntArray(int[] numbers)
            {
                foreach (int i in numbers)
                    Console.Write($"{i} ");

                Console.WriteLine();
            }

            PrintIntArray(GetPositiveOddTwoDigitNumbers(array, index));
            Console.ReadKey();
        }
    }
}