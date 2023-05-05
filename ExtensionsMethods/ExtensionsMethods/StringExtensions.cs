using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionsMethods
{
    public static class StringExtensions
    {
        public static int CountWords(this string str) =>
         str.Split(new char[] { ' ', '.', ',', ';',':','!','?','-','"' },
             StringSplitOptions.RemoveEmptyEntries).Length;
    }
}
