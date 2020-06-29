using System;
using System.Collections.Generic;
using System.Windows;

namespace AaDS_Project.Data
{
    public class Place
    {
        public Place(string name, int area, Point coordinates)
        {
            Name = name;
            Area = area;
            Coordinates = coordinates;

            NumberOfPeople = 0;
        }

        // TODO переместить в PlaceContainer?
        public List<int> Edges { get; set; }

        public Point Coordinates { get; set; }

        public string Name { get; set; }

        public int NumberOfPeople { get; set; }

        public int Area { get; set; }

        public double Density => Area / (double) NumberOfPeople;

        public override string ToString() => Name;
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

            // _places[0].Edges = new List<int> {1, 3, 5}; // Установка связей
        }

        public List<Place> GetPlaces() => _places;

        // TODO возможно int index
        public List<int> GetWay(string start, string finish)
        {
            var way = new List<int>();
            var minDensity = double.MaxValue;

            // TODO поиск пути DFS
            // way - искомый путь, minDensity - минимальная концентрация людей, позволяет получить "лучший" путь, сравнивая
            // с localDensity при полном проходе DFS. DFS хранит путь и localDensity - сумма концентраций в каждой пройденой точке,
            // за исключением точки назначения

            return way;
        }
    }
}