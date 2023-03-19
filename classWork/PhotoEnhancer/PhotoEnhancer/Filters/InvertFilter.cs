using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class InvertFilter : PixelFilter
    {
        public override ParameterInfo[] GetParametersInfo()
        {
            return new ParameterInfo[0];
        }

        public override Pixel ProcessPixel(Pixel pixel, double[] parameters)
        {
            return ~pixel;
            
        }

        public override string ToString()
        {
            return "Инверсия";
        }
    }
}
