using Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ocp
{
    public class GRectangle : IDrawable
    {
        Geometry.GRectangle gRectangle;
        public GRectangle(Geometry.GRectangle gRectangle) 
        { 
            this.gRectangle = gRectangle;
        }
        public void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
