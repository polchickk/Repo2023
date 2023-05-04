using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class LeftTransformer : ITransformer<LeftParameters>
    {
        Size oldSize { get; set; }
        double angleInRadians { get; set; }

        public Size ResultSize { get; private set; }

        public void Initialize(Size size, LeftParameters parameters)
        {
            oldSize = size;
            angleInRadians = parameters.AngleInDegrees * Math.PI / 180;
            ResultSize = new Size(
                     (int)(size.Width * Math.Cos(angleInRadians) +
                    size.Height * Math.Sin(angleInRadians)),
                     (int)Math.Sqrt(size.Height * size.Height + Math.Pow(size.Height * Math.Tan(angleInRadians), 2)));
        }

        public Point? MapPoint(Point point)
        {
            point=new Point((int)(point.X- point.Y * Math.Tan(angleInRadians)), point.Y);
            var x=point.X;
            var y=(int)Math.Sqrt(point.Y* point.Y + Math.Pow(point.Y * Math.Tan(angleInRadians),2));
           
            
            if (x < 0 || x >= oldSize.Width || y < 0 || y >= oldSize.Height)
                return null;

            return new Point(x, y);
        }
    }
}
