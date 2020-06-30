#region

using System.Collections.Generic;
using System.Linq;
using System.Windows;

#endregion

namespace AaDS_Project.Data
{
    public class Place
    {
        public Place(string name, int area, Point coordinate)
        {
            Name = name;
            Area = area;
            Coordinate = coordinate;

            NumberOfPeople = 0;
        }

        public List<int> Edges { get; set; }

        public string Name { get; }

        public int NumberOfPeople { get; set; }

        public int Area { get; }

        public double Density => (double)NumberOfPeople / Area;

        public Point Coordinate { get; }

        public override string ToString() => Name;
    }


    // Возможно этот класс не понадобится, так как будем инициализировать каждое место вручную
    public static class Places
    {
        public static readonly List<string> Names = new List<string>
        {
            "A building", "C building", "B building", "E building", "F building", "D building", "S building", "G building",
            "M building", "L building", "South Promenade", "North Promenade", "Parkland", "9 building", "10 building",
            "11 building", "8 building", "7 building", "6 building", "5 building", "4 building", "3 building", "2 building",
            "1 building","Ajax 1"
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
                new Place("A building", 400, new Point(740, 585)), // 0
                new Place("C building", 120, new Point(815, 585)), // 1
                new Place("B building", 120, new Point(695, 595)), // 2
                new Place("E building", 150, new Point(835, 545)), // 3
                new Place("F building", 140, new Point(880, 505)), // 4
                new Place("D building", 200, new Point(625, 600)), // 5
                new Place("S building", 170, new Point(535, 600)), // 6
                new Place("G building", 160, new Point(525, 655)), // 7
                new Place("M building", 200, new Point(740, 725)), // 8
                new Place("L building", 200, new Point(480, 745)), // 9
                new Place("South Promenade", 100, new Point(780, 225)), // 10
                new Place("North Promenade", 100, new Point(480, 235)), // 11
                new Place("Parkland", 300, new Point(710, 435)), // 12
                new Place("9 building", 200, new Point(940, 430)), // 13
                new Place("10 building", 200, new Point(970, 330)), // 14
                new Place("11 building", 200, new Point(980, 240)), // 15
                new Place("8 building", 200, new Point(330, 600)), // 16
                new Place("7 building", 200, new Point(230, 450)), // 17
                new Place("6 building", 200, new Point(190, 300)), // 18
                new Place("5 building", 200, new Point(290, 250)), // 19
                new Place("4 building", 200, new Point(300, 350)), // 20
                new Place("3 building", 200, new Point(340, 420)), // 21
                new Place("2 building", 200, new Point(385, 480)), // 22
                new Place("1 building", 200, new Point(440, 545)), // 23
                new Place("Ajax 1", 200, new Point(140, 180)) // 24
            };

            _places[0].Edges = new List<int> { 1, 2, 8, 12 };
            _places[1].Edges = new List<int> { 0, 3, 8 };
            _places[2].Edges = new List<int> { 0, 5, 8 };
            _places[3].Edges = new List<int> { 1, 4, 12 };
            _places[4].Edges = new List<int> { 3, 13 };
            _places[5].Edges = new List<int> { 2, 6, 7 };
            _places[6].Edges = new List<int> { 5, 7, 23 };
            _places[7].Edges = new List<int> { 5, 6, 9 };
            _places[8].Edges = new List<int> { 0, 1, 2 };
            _places[9].Edges = new List<int> { 7, 16, 23 };
            _places[10].Edges = new List<int> { 11, 12, 13, 14, 15 };
            _places[11].Edges = new List<int> { 10, 12, 19, 20, 21 };
            _places[12].Edges = new List<int> { 0, 3, 10, 11, 13, 22, 23 };
            _places[13].Edges = new List<int> { 4, 10, 12, 14 };
            _places[14].Edges = new List<int> { 10, 13, 15 };
            _places[15].Edges = new List<int> { 10, 14 };
            _places[16].Edges = new List<int> { 9, 17, 22, 23 };
            _places[17].Edges = new List<int> { 16, 18, 19, 20, 21, 22 };
            _places[18].Edges = new List<int> { 17, 19, 20, 24 };
            _places[19].Edges = new List<int> { 17, 18, 20, 24 };
            _places[20].Edges = new List<int> { 17, 18, 19, 21 };
            _places[21].Edges = new List<int> { 11, 17, 20, 22 };
            _places[22].Edges = new List<int> { 12, 16, 17, 21, 23 };
            _places[23].Edges = new List<int> { 6, 9, 12, 16, 22 };
            _places[24].Edges = new List<int> { 18, 19 };
        }

        public List<Place> GetPlaces => _places;

        public List<Place> GetWay(int start, int finish)
        {
            var way = new List<int>();
            const double minDensity = double.MaxValue;
            var path = new List<int>();
            var visited = new List<int>();

            DFS(start, finish, path, visited, minDensity, 0, way);

            return way.Select(i => _places[i]).ToList();
        }

        private double DFS(int current, int finish, List<int> path, List<int> visited, double minDensity,
            double localDensity, List<int> way)
        {
            var place = _places[current];

            path.Add(current);
            visited.Add(current);

            if (current == finish && localDensity - _places[current].Density < minDensity)
            {
                way.Clear();
                way.AddRange(path);

                path.RemoveAt(path.Count - 1);
                visited.RemoveAt(visited.Count - 1);

                return localDensity - _places[current].Density;
            }

            foreach (var vertex in place.Edges)
                if (!visited.Contains(vertex))
                    minDensity = DFS(vertex, finish, path, visited, minDensity, localDensity + place.Density, way);

            path.RemoveAt(path.Count - 1);
            visited.RemoveAt(visited.Count - 1);

            return minDensity;
        }

        public void AddPerson(string name)
        {
            foreach (var place in _places)
            {
                if (place.Name == name)
                {
                    place.NumberOfPeople++;
                }
            }
        }
    }
}