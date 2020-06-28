using System;
using System.Collections.Generic;

namespace AaDS_Project.Data
{
    public class Place
    {
        public Place(string name, int area)
        {
            Name = name;
            Area = area;

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
    }

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
                new Place("Home", 0),
                new Place("Shop", 0)
            };
        }

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