using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;

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
                new Place("Home", 0, new Point(0, 0)),
                new Place("Shop", 0, new Point(0, 0))
            };

            // _places[0].Edges = new List<int> {1, 3, 5}; // Установка связей
        }

        // TODO возможно int index
        public List<Place> GetWay(int start, int finish)
        {

            // TODO поиск пути DFS
            // way - искомый путь, minDensity - минимальная концентрация людей, позволяет получить "лучший" путь, сравнивая
            // с localDensity при полном проходе DFS. DFS хранит путь и localDensity - сумма концентраций в каждой пройденой точке,
            // за исключением точки назначения

            //var minElement = tuple.OrderBy(x=>x.Item1).Min(x=>x.Item2).ToList();


            var way = new List<int>();
            var minDensity = double.MaxValue;
            var path = new List<int>();
            var visited = new List<int>();

            double _ = DFS(start, finish, path, visited, minDensity, 0, way);

            return GetString(way);
        }

        private double DFS(int current, int finish, List<int> path, List<int> visited, double minDensity, double localDensity, List<int> way)
        {

            var place = _places[current];

            path.Add(current);
            visited.Add(current);

            if (current == finish && localDensity - _places[current].Density < minDensity)
            {

                way.Clear();
                way.AddRange(path);

                minDensity = localDensity;

                path.RemoveAt(path.Count - 1);
                visited.RemoveAt(visited.Count - 1);

                return minDensity;
            }

            foreach (var vertex in place.Edges)
            {
                if (!visited.Contains(vertex))
                {
                    minDensity = DFS(vertex, finish, path, visited, minDensity, localDensity + place.Density, way);
                }
            }

            path.RemoveAt(path.Count - 1);
            visited.RemoveAt(visited.Count - 1);

            return minDensity;
        }

        private List<Place> GetString(List<int> way) => way.Select(i => _places[i]).ToList();

    }
}