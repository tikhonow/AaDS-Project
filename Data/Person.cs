#region

using System.Collections.Generic;

#endregion

namespace AaDS_Project.Data
{
    public class Person
    {
        private static uint _count = 0;

        public Person(string name, Dictionary<Time, string> schedule)
        {
            Name = name;
            Schedule = schedule;

            Id = _count;
            _count++;
        }

        public string Name { get; set; }

        public uint Id { get; }

        /// <summary>График, позволяющий установить местороложение Person в указанное время</summary>
        public Dictionary<Time, string> Schedule { get; set; }

        public bool IsEmpty => Name == null || Schedule == null;

        public override string ToString() => Name;
    }
}