﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    class Pixel
    {
        private double r;
        public double R 
        {
            get => r; //{return r;}
            set => r = CheckValue(value);
        }

        private double g;
        public double G
        {
            get => g; 
            set => g = CheckValue(value);
        }

        private double b;
        public double B
        {
            get => b;
            set => b = CheckValue(value);
        }

        private double CheckValue(double val)
        {
            if (val < 0 || val > 1)
                throw new ArgumentException("Невернойне значение яркости канала!");

            return val;
        }
        
    }
}
