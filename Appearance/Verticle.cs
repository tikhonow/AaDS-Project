#region

using System;
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

            _verticleDensityColor = GetColor(place.Density);
        }

        private static SolidColorBrush GetColor(double density)
        {
            if (density > 1)
                density = 1;

            var ind = (int) (density * 10);

            return ind switch
            {
                0 => Brushes.Lime,
                1 => Brushes.Chartreuse,
                2 => Brushes.LawnGreen,
                3 => Brushes.LawnGreen,
                4 => Brushes.GreenYellow,
                5 => Brushes.Yellow,
                6 => Brushes.Goldenrod,
                7 => Brushes.DarkOrange,
                8 => Brushes.OrangeRed,
                9 => Brushes.OrangeRed,
                10 => Brushes.Red,
                _ => Brushes.Blue
            };
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