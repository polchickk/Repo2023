using PhotoEnhancer.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class InvertFilter : PixelFilter
    {
        public InvertFilter() : base(new InvertParameters()) { }
 

        public override Pixel ProcessPixel(Pixel pixel, IParameters parameters)
        {
            return ~pixel;
            
        }

        public override string ToString()
        {
            return "Инверсия";
        }
    }
}
