using System;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Drawing;

namespace AaDS_Project.Appearance
{
    public class Map : Drawable
    {
        private BitmapImage _bmp = new BitmapImage(new Uri("..\\..\\..\\Resources\\map.jpg", UriKind.Relative));
        public double width;
        public double height;

        public Map()
        {
            width = _bmp.Width;
            height = _bmp.Height;
        }

        public override void Draw(DrawingContext ctx, ViewPort vp)
        {
            Rect drawingRegion = new Rect(vp.x1, vp.y1, _bmp.Width, _bmp.Height);
            ctx.DrawImage(_bmp, drawingRegion);
        }

        
    }
}