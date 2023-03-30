﻿using PhotoEnhancer.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class GrayScaleFilter : PixelFilter
    {
        public GrayScaleFilter() : base(new EmptyParameters()) { }

        public override Pixel ProcessPixel(Pixel pixel, IParameters parameters)
        {
            var lightness = 0.3 * pixel.R + 0.6 * pixel.G + 0.1 * pixel.B;
            return new Pixel(lightness, lightness, lightness);
        }

        public override string ToString()
        {
            return "Оттенки серого";
        }
    }
}
