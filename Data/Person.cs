#region

using System.Collections.Generic;

#endregion

namespace AaDS_Project.Data
{
    public struct Person
    {
        private string _name;
        private Dictionary<Time, string> _schedule;

        public Person(string name, Dictionary<Time, string> schedule)
        {
            this._name = name;
            this._schedule = schedule;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        /// <summary>График, позволяющий установить местороложение Person в указанное время</summary>
        public Dictionary<Time, string> Schedule
        {
            get => _schedule;
            set => _schedule = value;
        }

        public bool IsEmpty => this._name == null || this._schedule == null;

        public override string ToString() => this._name;
    }
}