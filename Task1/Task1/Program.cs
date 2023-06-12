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
            int[] array = { -5, 0, 12, 7, 25, 10, 91, 8, 2026,161 };

             static int[] GetEvenDigitSumsDescending(int[] numbers)
            {
                return numbers
                    .Where(n => n > 0 && n % 2 == 0)
                    .Select(n => n.ToString().Sum(c => c - '0'))
                    .Distinct()
                    .OrderByDescending(sum => sum)
                    .ToArray();
            }

            int[] evenDigitSums = GetEvenDigitSumsDescending(array);
            Console.WriteLine(string.Join(", ", evenDigitSums));

            Console.ReadKey();
        }
    }
}