using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Person<T>
    {
        public string Name { get; set; }    

        public T Description { get; set; }
    }
}
