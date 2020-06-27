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
        public ViewPort vp;

        private ImageBrush _image;

        public Map()
        {
            vp.x = 0;
            vp.y = 0;
            vp.scale = 1;
        }

        public override void Draw(DrawingContext ctx)
        {

        }
    }
}
