#region

using System.Windows.Media;

#endregion

namespace AaDS_Project.Appearance
{
    public struct ViewPort
    {
        public double X1, Y1, X2, Y2, Scale;
    }

    public abstract class Drawable
    {
        public abstract void Draw(DrawingContext ctx, ViewPort vp);
    }
}