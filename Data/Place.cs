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
        public List<int> GetWay(int start, int finish)
        {

            // TODO поиск пути DFS
            // way - искомый путь, minDensity - минимальная концентрация людей, позволяет получить "лучший" путь, сравнивая
            // с localDensity при полном проходе DFS. DFS хранит путь и localDensity - сумма концентраций в каждой пройденой точке,
            // за исключением точки назначения

            //var minElement = tuple.OrderBy(x=>x.Item1).Min(x=>x.Item2).ToList();


            var way = new List<int>(); //TODO: Rename
            var minDensity = double.MaxValue;
            var path = new List<int>();
            var visited = new List<int>();

            List<int> resultWay = DFS(start, finish, path, visited, minDensity, 0, way);

            return resultWay;
        }

        private List<int> DFS(int current, int finish, List<int> path, List<int> visited, double minDensity, double localDensity, List<int> way)
        {

            var place = _places[current];

            path.Add(current);
            visited.Add(current);

            if (current == finish && localDensity - _places[current].Density < minDensity)
            {
                for (int i = 0; i < path.Count; i++)
                {
                    way.Add(path[i]);
                }

                minDensity = localDensity;

                path.RemoveAt(path.Count - 1);
                visited.RemoveAt(visited.Count - 1);

                return way;

            }

            for (int i = 0; i < place.Edges.Count; i++)
            {
                if (!visited.Contains(place.Edges[i]))
                {
                    DFS(place.Edges[i], finish, path, visited, minDensity, localDensity + _places[current].Density, way);
                }
            }

            path.RemoveAt(path.Count - 1);
            visited.RemoveAt(visited.Count - 1);

            return way;
        }
    }
}