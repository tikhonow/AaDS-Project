#region

using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using AaDS_Project.Data;

#endregion

namespace AaDS_Project.Appearance
{
    public class Way : Drawable
    {
        private readonly PathGeometry _geometry = new PathGeometry();
        private readonly List<Place> _places;

        public Way(List<Place> places)
        {
            _places = places;
        }

        public override void Draw(DrawingContext ctx, ViewPort vp)
        {
            _geometry.Clear();
            var path = new PathFigure();
            path.StartPoint = new Point(
                _places[0].Coordinate.X + vp.X1 / vp.Scale,
                _places[0].Coordinate.Y + vp.Y1 / vp.Scale);

            for (var i = 1; i < _places.Count; i++)
            {
                var pt = new Point(
                    _places[i].Coordinate.X + vp.X1 / vp.Scale,
                    _places[i].Coordinate.Y + vp.Y1 / vp.Scale);

                var edge = new LineSegment(pt, true);
                path.Segments.Add(edge);
            }

            _geometry.Figures.Add(path);

            ctx.DrawGeometry(Brushes.Transparent, new Pen(Brushes.Red, 3), _geometry);
        }
    }
}