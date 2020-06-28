namespace AaDS_Project.Data
{
    public struct Place
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
}