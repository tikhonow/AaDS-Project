#region

using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

#endregion

namespace AaDS_Project.Appearance
{
    public class VisualHost : FrameworkElement
    {
        public VisualCollection visualCollection;

        public VisualHost()
        {
            visualCollection = new VisualCollection(this);
        }

        protected override int VisualChildrenCount => visualCollection.Count;

        protected override Visual GetVisualChild(int index)
        {
            return visualCollection[index];
        }

        public void Redraw(List<Drawable> drawables, ViewPort vp)
        {
            var drawingVisuals = new DrawingVisual();

            visualCollection.Clear();

            using (var dc = drawingVisuals.RenderOpen())
            {
                foreach (var drawable in drawables) drawable.Draw(dc, vp);
            }

            visualCollection.Add(drawingVisuals);
        }
    }
}