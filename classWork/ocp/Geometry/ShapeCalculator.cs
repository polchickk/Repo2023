using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public static class ShapeCalculator
    {
        public static double GetOverAllArea(List<IMeasuarable> shapes) 
        {
            double result = 0;

            foreach (IMeasuarable shape in shapes) 
                result+= shape.Area;

            return result;
        }


    }
}
