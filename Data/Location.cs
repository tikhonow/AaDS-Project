namespace AaDS_Project.Data
{
    public enum Location
    {
        Home = 0,
        Shop = 1,
        None = 99
    }

    public struct Place
    {
        private Location _name; // REDO maybe string
        private int _numberOfPeople;

        public Location Name
        {
            get => _name;
            set => _name = value;
        }

        public int NumberOfPeople
        {
            get => _numberOfPeople;
            set => _numberOfPeople = value;
        }

        public override string ToString() => this._name.ToString();
    }
}