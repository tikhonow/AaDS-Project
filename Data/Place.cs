namespace AaDS_Project.Data
{
    public struct Place
    {
        private string _name;
        private int _numberOfPeople;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int NumberOfPeople
        {
            get => _numberOfPeople;
            set => _numberOfPeople = value;
        }

        public override string ToString() => this._name;
    }
}