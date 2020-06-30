#region

using System.Globalization;
using System.Windows;
using System.Windows.Media;
using AaDS_Project.Data;

#endregion

namespace AaDS_Project.Appearance
{
    internal class Verticle : Drawable
    {
        private readonly FormattedText _congestionText;
        private readonly FormattedText _formattedText;

        private Point _placeCoordinate;

        private readonly SolidColorBrush _verticleDensityColor;

        public Verticle(Place place)
        {
            _placeCoordinate = place.Coordinate;

            _formattedText = new FormattedText(place.Name,
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface("Verdana"),
                14,
                Brushes.Black);

            _congestionText = new FormattedText(place.Density.ToString("0.00"),
                CultureInfo.GetCultureInfo("en-us"),
                FlowDirection.LeftToRight,
                new Typeface("Verdana"),
                12,
                Brushes.Black);

            if (place.Density > 1)
                _verticleDensityColor = Brushes.Red;
            else if (place.Density > 0.6)
                _verticleDensityColor = Brushes.Yellow;
            else
                _verticleDensityColor = Brushes.Green;
        }

        public override void Draw(DrawingContext ctx, ViewPort vp)
        {
            var pt = new Point(
                _placeCoordinate.X + vp.X1 / vp.Scale,
                _placeCoordinate.Y + vp.Y1 / vp.Scale);

            ctx.DrawEllipse(_verticleDensityColor, new Pen(Brushes.Beige, 1), pt, 10, 10);
            ctx.DrawText(_formattedText, new Point(pt.X - 30, pt.Y + 5));
            ctx.DrawText(_congestionText, new Point(pt.X - 6, pt.Y - 8));
        }
    }
}