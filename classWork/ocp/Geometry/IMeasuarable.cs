using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public interface IMeasuarable
    {
        double Area { get; }
        double Perimetr { get; }
    }
}
