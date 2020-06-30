using System.Windows.Media;
using AaDS_Project.Data;
using System.Windows;
using System.Globalization;

namespace AaDS_Project.Appearance
{
    class Verticle : Drawable
    {
        private FormattedText _formattedText;

        private FormattedText _congestionText;

        private SolidColorBrush _verticleDensityColor;

        private Point _placeCoordinate;

        public Verticle (Place place)
        {
            _placeCoordinate = place.Coordinate;

            _formattedText = new FormattedText(place.Name,
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface("Verdana"),
                14,
                Brushes.Black);

            _congestionText = new FormattedText(place.Density.ToString(),
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface("Verdana"),
                12,
                Brushes.Black);

            place.NumberOfPeople = 500;
            if (place.Density > 1)
            {
                _verticleDensityColor = Brushes.Red;
            }
            else if (place.Density > 0.6)
            {
                _verticleDensityColor = Brushes.Yellow;
            }
            else
            {
                _verticleDensityColor = Brushes.Green;
            }
        }

        public override void Draw(DrawingContext ctx, ViewPort vp)
        {

            Point pt = new Point(
                _placeCoordinate.X + vp.x1 / vp.scale,
                _placeCoordinate.Y + vp.y1 / vp.scale);

            ctx.DrawEllipse(_verticleDensityColor, new Pen(Brushes.Beige, 1), pt, 10, 10);
            ctx.DrawText(_formattedText, new Point(pt.X - 30, pt.Y + 5));
            ctx.DrawText(_congestionText, new Point(pt.X - 6, pt.Y - 8));
        }
    }
}
