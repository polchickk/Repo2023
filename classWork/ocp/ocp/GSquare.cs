using Geometry;
using System.Drawing;

namespace ocp
{
    public class GSquare : IDrawable
    {
        Geometry.GSquare square;
        public GSquare(Geometry.GSquare square)
        {
            this.square = square;
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
