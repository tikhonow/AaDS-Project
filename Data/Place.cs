﻿using System;
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

        public double Density => NumberOfPeople / Area;

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
                new Place("A building", 400, new Point(740, 585)),
                new Place("C building", 120, new Point(815, 585)),
                new Place("B building", 120, new Point(695, 595)),
                new Place("E building", 150, new Point(835, 545)),
                new Place("F building", 140, new Point(880, 505)),
                new Place("D building", 200, new Point(625, 600)),
                new Place("S building", 170, new Point(535, 600)),
                new Place("G building", 160, new Point(525, 655)),
                new Place("M building", 200, new Point(740, 725)),
                new Place("L building", 200, new Point(480, 745)),
                new Place("South Promenade", 100, new Point(780, 225)),
                new Place("North Promenade", 100, new Point(480, 235)),
                new Place("Parkland", 300, new Point(710, 435)),
                new Place("9 building", 200, new Point(940, 430)),
                new Place("10 building", 200, new Point(970, 330)),
                new Place("11 building", 200, new Point(980, 240)),
                new Place("8 building", 200, new Point(330, 600)),
                new Place("7 building", 200, new Point(230, 450)),
                new Place("6 building", 200, new Point(190, 300))
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