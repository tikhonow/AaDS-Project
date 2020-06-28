#region

using System.Collections.Generic;

#endregion

namespace AaDS_Project.Data
{
    public class Person
    {
        private static int _count = 0;
        private readonly int _id;

        public Person(string name, Dictionary<Time, string> schedule)
        {
            Name = name;
            Schedule = schedule;

            _id = _count;
            _count++;
        }

        public string Name { get; set; }

        public int Id => _id;

        /// <summary>График, позволяющий установить местороложение Person в указанное время</summary>
        public Dictionary<Time, string> Schedule { get; set; }

        public bool IsEmpty => Name == null || Schedule == null;

        public override string ToString() => Name;
    }

    public class PersonContainer
    {
        // TODO
    }
}