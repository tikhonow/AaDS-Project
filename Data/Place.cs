using System;
using System.Collections.Generic;
using System.Windows;

namespace AaDS_Project.Data
{
    public class Place
    {
        public Place(string name, int area, Point coordinate)
        {
            Name = name;
            Area = area;
            Coordinate = coordinate;

            Edges = new List<int>();
            NumberOfPeople = 0;
        }

        // TODO переместить в PlaceContainer?
        public List<int> Edges { get; set; }

        public string Name { get; set; }

        public int NumberOfPeople { get; set; }

        public int Area { get; set; }

        public double Density => Area / (double) NumberOfPeople;

        public override string ToString() => Name;

        public Point Coordinate { get; set; }
    }


    // Возможно этот класс не понадобится, так как будем инициализировать каждое место вручную
    public static class Places
    {
        public static readonly List<string> Names = new List<string>
        {
            "Home", "Shop", "None"
        };
    }

    public class PlaceContainer
    {

        private readonly List<Place> _places;

        public PlaceContainer()
        {
            _places = new List<Place>
            {
                // 180 - X offset, 115 - Y offset
                new Place("A building", 200, new Point(740, 585)),
                new Place("C building", 120, new Point(815, 585)),
                new Place("B building", 120, new Point(695, 595))
            };
        }


        public List<Place> GetPlaces() => new List<Place>(_places);


        // TODO возможно int index
        public List<int> GetWay(string start, string finish)
        {
            var way = new List<int>();
            var minDensity = double.MaxValue;

            // TODO поиск пути DFS

            return way;
        }
    }
}