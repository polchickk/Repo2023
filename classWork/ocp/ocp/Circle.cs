﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ocp
{

    public class Circle : Shape
    {
        public Point Center { get; set; }
        public double Radius { get; set; }

        public override double Area => Math.PI * Radius * Radius;

        public Circle(double x, double y, double r)
        {
            Center = new Point(x, y);
            Radius = r;
        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
