using PhotoEnhancer.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class InvertFilter : PixelFilter<InvertParameters>
    {

        public override Pixel ProcessPixel(Pixel pixel, InvertParameters parameters)
        {
            return ~pixel;
            
        }

        public override string ToString()
        {
            return "Инверсия";
        }
    }
}
