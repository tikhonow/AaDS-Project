using System.Collections.Generic;

namespace AaDS_Project.Data
{
    public class Place
    {
        public Place(string name, int area)
        {
            Name = name;
            Area = area;
            NumberOfPeople = 0;
        }

        public string Name { get; set; }

        public int NumberOfPeople { get; set; }

        public int Area { get; set; }

        public double Density => Area / (double) NumberOfPeople;

        public override string ToString() => Name;
    }

    public static class Places
    {
        public static List<string> Names = new List<string>
        {
            "Home", "Shop", "None"
        };
    }
}