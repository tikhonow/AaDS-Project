using System;
using System.Collections.Generic;
using System.Text;
using AaDS_Project.Data;
using System.Windows.Media;
using System.Windows;

namespace AaDS_Project.Appearance
{
    public class Way : Drawable
    {
        List<Place> _places;
        PathGeometry _geometry = new PathGeometry();

        public Way(List<Place> places)
        {
            _places = places;
        }

        public override void Draw(DrawingContext ctx, ViewPort vp)
        {
            _geometry.Clear();
            PathFigure path = new PathFigure();
            path.StartPoint = new Point(
                _places[0].Coordinate.X + vp.x1 / vp.scale,
                _places[0].Coordinate.Y + vp.y1 / vp.scale);

            for (int i = 1; i < _places.Count; i++)
            {
                Point pt = new Point(
                    _places[i].Coordinate.X + vp.x1 / vp.scale,
                    _places[i].Coordinate.Y + vp.y1 / vp.scale);

                LineSegment edge = new LineSegment(pt, true);
                path.Segments.Add(edge);
            }

            _geometry.Figures.Add(path);

            ctx.DrawGeometry(Brushes.Transparent , new Pen(Brushes.Red, 3), _geometry);
        }
    }
}
