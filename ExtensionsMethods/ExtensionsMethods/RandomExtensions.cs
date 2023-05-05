using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionsMethods
{
    public static class RandomExtensions
    {
        public static double FlatDistribution(this Random random, double a, double b)
        {
            if (a >= b) throw new ArgumentException();

            return a+random.NextDouble()*(b-a);
        }
    }
}
