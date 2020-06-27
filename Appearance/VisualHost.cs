using System;
using System.Windows;
using System.Collections;
using System.Text;
using System.Windows.Media;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Windows.Controls;


namespace AaDS_Project.Appearance
{
    public class VisualHost : FrameworkElement
    {
        public VisualCollection visualCollection;

        public VisualHost()
        {
            visualCollection = new VisualCollection(this);
        }

        protected override Visual GetVisualChild(int index)
        {
            return visualCollection[index];
        }

        protected override int VisualChildrenCount => visualCollection.Count;

        public void Redraw(List<Drawable> drawables, ViewPort vp)
        {
            DrawingVisual drawingVisuals = new DrawingVisual();

            visualCollection.Clear();

            using (DrawingContext dc = drawingVisuals.RenderOpen())
            {
                foreach (var drawable in drawables)
                {
                    drawable.Draw(dc, vp);
                }
            }

            visualCollection.Add(drawingVisuals);
        }
    }
}