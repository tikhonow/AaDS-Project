#region

using System.Collections.Generic;
using AaDS_Project.Data;

#endregion

namespace AaDS_Project.Appearance

{
    public class Layout
    {
        private readonly Map _map = new Map();
        private readonly double _cvsHeight;

        private readonly double _cvsWidth;

        public List<Drawable> Drawables = new List<Drawable>();

        private double _lastX;
        private double _lastY;

        public VisualHost Visuals = new VisualHost();
        protected ViewPort Vp;

        public Layout(double width, double height, List<Place> places)
        {
            Vp.X1 = 0;
            Vp.Y1 = 0;
            Vp.X2 = _cvsWidth;
            Vp.Y2 = _cvsHeight;
            Vp.Scale = 1;

            _cvsWidth = width;
            _cvsHeight = height;

            Drawables.Add(_map);
            foreach (var place in places)
            {
                var verticle = new Verticle(place);
                Drawables.Add(verticle);
            }
        }

        public void ChangeVerticles(List<Place> places)
        {
            Drawables.Clear();
            Drawables.Add(_map);
            foreach (var place in places)
            {
                var verticle = new Verticle(place);
                Drawables.Add(verticle);
            }
        }

        public void OnHold(double x, double y)
        {
            _lastX = x;
            _lastY = y;
        }

        public void OnMove(double x, double y)
        {
            var dx = (x - _lastX) / Vp.Scale;
            var dy = (y - _lastY) / Vp.Scale;

            if (Vp.X2 + dx > -300 && Vp.X1 + dx < 0)
            {
                Vp.X1 += dx;
                Vp.X2 += dx;
            }

            if (Vp.Y1 + dy > -500 && Vp.Y1 + dy < 0)
            {
                Vp.Y1 += dy;
                Vp.Y2 += dy;
            }

            _lastX = x;
            _lastY = y;
        }

        public void ZoomIn(double x, double y)
        {
            if (Vp.Scale < 4)
            {
                var NewWidth = (int) (Vp.X2 - Vp.X1) / 2;
                var NewHeight = (int) (Vp.Y2 - Vp.Y1) / 2;
                Vp.X1 = x / Vp.Scale + Vp.X1 - NewWidth / 2;
                Vp.Y1 = y / Vp.Scale + Vp.Y1 - NewHeight / 2;
                Vp.Scale *= 2;
                Vp.X2 = Vp.X1 + NewWidth;
                Vp.Y2 = Vp.Y1 + NewHeight;
            }
        }

        public void ZoomOut(double x, double y)
        {
            if (Vp.Scale > 0.2) Vp.Scale /= 2;
            var NewWidth = (int) (Vp.X2 - Vp.X1) * 2;
            var NewHeight = (int) (Vp.Y2 - Vp.Y1) * 2;
            Vp.X1 = x / Vp.Scale + Vp.X1 - NewWidth / 2;
            Vp.Y1 = y / Vp.Scale + Vp.Y1 - NewHeight / 2;
            Vp.Scale /= 2;
            Vp.X2 = Vp.X1 + NewWidth;
            Vp.Y2 = Vp.Y1 + NewHeight;
        }

        public void Refresh() => Visuals.Redraw(Drawables, Vp);
    }
}