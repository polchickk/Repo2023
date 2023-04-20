using Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ocp
{

    public class GCircle : IDrawable
    {
        Geometry.GCircle circle;
        public GCircle(Geometry.GCircle circle)
        {
            this.circle = circle;
        }
        public void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
