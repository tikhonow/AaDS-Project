using System;
using System.Collections.Generic;
using System.Text;

namespace AaDS_Project.Appearance

{

    public class Layout
    {
        protected ViewPort vp;
        public VisualHost visuals = new VisualHost();
        public List<Drawable> drawables = new List<Drawable>();

        private Map _map = new Map();

        double cvs_width;
        double cvs_height;

        public Layout(double width, double height)
        {
            drawables.Add(_map);
            vp.x1 = 0;
            vp.y1 = 0;
            vp.x2 = cvs_width;
            vp.y2 = cvs_height;
            vp.scale = 1;

            cvs_width = width;
            cvs_height = height;
        }

        private double lastX;
        private double lastY;

        public void OnHold(double x, double y)
        {
            lastX = x;
            lastY = y;
        }

        public void OnMove(double x, double y)
        {
            double dx = (x - lastX) / vp.scale;
            double dy = (y - lastY) / vp.scale;

            if (vp.x2 + dx > -600  && vp.x1 + dx < 0)
            {
                vp.x1 += dx;
                vp.x2 += dx;
            }

            if (vp.y1 + dy > -150 && vp.y1 + dy < 0)
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
                int NewWidth = (int)(vp.x2 - vp.x1) / 2;
                int NewHeight = (int)(vp.y2 - vp.y1) / 2;
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
            int NewWidth = (int)(vp.x2 - vp.x1) * 2;
            int NewHeight = (int)(vp.y2 - vp.y1) * 2;
            vp.x1 = x / vp.scale + vp.x1 - NewWidth / 2;
            vp.y1 = y / vp.scale + vp.y1 - NewHeight / 2;
            vp.scale /= 2;
            vp.x2 = vp.x1 + NewWidth;
            vp.y2 = vp.y1 + NewHeight;
        }

        public void Refresh() => visuals.Redraw(drawables, vp);

    }
}