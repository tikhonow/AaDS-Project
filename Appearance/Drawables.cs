using System.Windows.Media;

namespace AaDS_Project.Appearance
{
    public struct ViewPort { public double x1, y1, x2, y2, scale; }

    public abstract class Drawable
    {
        public abstract void Draw(DrawingContext ctx, ViewPort vp);
    }
}