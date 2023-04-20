using System;
using System.Drawing;

namespace Geometry
{
        public class GSquare : IMeasuarable
        {
            public Point TopLeft { get; set; }
            public double Side { get; set; }

            public double Area => Side * Side;

            public GSquare(double x, double y, double side)
            {
                TopLeft = new Point(x, y);
                Side = side;
            }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public double Perimetr => 4*Side;
    }
}
