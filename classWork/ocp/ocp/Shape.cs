using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ocp
{
    public abstract class Shape
    {
        public abstract double Area { get; }
        public abstract void Draw();
    }
}
