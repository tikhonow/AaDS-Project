#region

using System.Collections.Generic;
using AaDS_Project.Data;

#endregion

namespace AaDS_Project.Appearance

{
    public class Layout
    {
        private readonly Map _map = new Map();
        private readonly double cvs_height;

        private readonly double cvs_width;

        public List<Drawable> drawables = new List<Drawable>();

        private double lastX;
        private double lastY;

        public VisualHost visuals = new VisualHost();
        protected ViewPort vp;

        public Layout(double width, double height, List<Place> places)
        {
            vp.x1 = 0;
            vp.y1 = 0;
            vp.x2 = cvs_width;
            vp.y2 = cvs_height;
            vp.scale = 1;

            cvs_width = width;
            cvs_height = height;

            drawables.Add(_map);
            foreach (var place in places)
            {
                var verticle = new Verticle(place);
                drawables.Add(verticle);
            }
        }

        public void OnHold(double x, double y)
        {
            lastX = x;
            lastY = y;
        }

        public void OnMove(double x, double y)
        {
            var dx = (x - lastX) / vp.scale;
            var dy = (y - lastY) / vp.scale;

            if (vp.x2 + dx > -300 && vp.x1 + dx < 0)
            {
                vp.x1 += dx;
                vp.x2 += dx;
            }

            if (vp.y1 + dy > -500 && vp.y1 + dy < 0)
            {
                vp.y1 += dy;
                vp.y2 += dy;
            }

            lastX = x;
            lastY = y;
        }

        public void ZoomIn(double x, double y)
        {
            if (vp.scale < 4)
            {
                var NewWidth = (int) (vp.x2 - vp.x1) / 2;
                var NewHeight = (int) (vp.y2 - vp.y1) / 2;
                vp.x1 = x / vp.scale + vp.x1 - NewWidth / 2;
                vp.y1 = y / vp.scale + vp.y1 - NewHeight / 2;
                vp.scale *= 2;
                vp.x2 = vp.x1 + NewWidth;
                vp.y2 = vp.y1 + NewHeight;
            }
        }

        public void ZoomOut(double x, double y)
        {
            if (vp.scale > 0.2) vp.scale /= 2;
            var NewWidth = (int) (vp.x2 - vp.x1) * 2;
            var NewHeight = (int) (vp.y2 - vp.y1) * 2;
            vp.x1 = x / vp.scale + vp.x1 - NewWidth / 2;
            vp.y1 = y / vp.scale + vp.y1 - NewHeight / 2;
            vp.scale /= 2;
            vp.x2 = vp.x1 + NewWidth;
            vp.y2 = vp.y1 + NewHeight;
        }

        public void Refresh() => visuals.Redraw(drawables, vp);
    }
}