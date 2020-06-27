using System.Windows.Media;

namespace AaDS_Project.Appearance
{
    public struct ViewPort
    {
        public int x, y;
        public double scale;
    }

    public abstract class Drawable
    {
        public abstract void Draw(DrawingContext ctx);
    }
}
