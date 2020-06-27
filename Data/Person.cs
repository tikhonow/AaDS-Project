#region

using System.Collections.Generic;

#endregion

namespace AaDS_Project.Data
{
    public struct Person
    {
        public Person(string name, Dictionary<Time, string> schedule)
        {
            Name = name;
            Schedule = schedule;
        }

        public string Name { get; set; }

        /// <summary>График, позволяющий установить местороложение Person в указанное время</summary>
        public Dictionary<Time, string> Schedule { get; set; }

        public bool IsEmpty => Name == null || Schedule == null;

        public override string ToString() => Name;
    }
}