#region

using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

#endregion

namespace AaDS_Project.Appearance
{
    public class Map : Drawable
    {
        private readonly BitmapImage
            _bmp = new BitmapImage(new Uri("..\\..\\..\\Resources\\map.jpg", UriKind.Relative));

        public double height;
        public double width;

        public Map()
        {
            width = _bmp.Width;
            height = _bmp.Height;
        }

        public override void Draw(DrawingContext ctx, ViewPort vp)
        {
            var drawingRegion = new Rect(vp.x1, vp.y1, _bmp.Width, _bmp.Height);
            ctx.DrawImage(_bmp, drawingRegion);
        }
    }
}