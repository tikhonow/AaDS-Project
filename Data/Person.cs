#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace AaDS_Project.Data
{
    public class Person
    {
        private static int _count = 0;

        public Person(string name, Dictionary<Time, string> schedule)
        {
            Name = name;
            Schedule = schedule;

            Id = _count;
            _count++;
        }

        public string Name { get; }

        public int Id { get; }

        /// <summary>График, позволяющий установить местороложение Person в указанное время</summary>
        public Dictionary<Time, string> Schedule { get; }

        public bool IsEmpty => Name == null || Schedule == null;

        public override string ToString() => Name;
    }

    public class PersonContainer
    {
        public PersonContainer()
        {
            Users = new List<Person>();
        }

        public PersonContainer(int num)
        {
            Users = new List<Person>();

            var random = new Random();
            RandomizeUsers(num, random);
        }

        public List<Person> Users { get; }

        private void RandomizeUsers(int numberOfUsers, Random random)
        {
            for (var i = 0; i < numberOfUsers; i++)
            {
                var schedule = new Dictionary<Time, string>();
                for (var j = Time.T0; j <= Time.T23; j++) 
                    schedule.Add(j, Places.Names[random.Next(Places.Names.Count)]);

                var name = UsersNames.Names[random.Next(UsersNames.Names.Count)];
                var person = new Person(name, schedule);

                Users.Add(person);
            }
        }

        /*private static Time RandomizeTime(Random random)
        {
            var min = (int)Enum.GetValues(typeof(Time)).Cast<Time>().Min();
            var max = (int)Enum.GetValues(typeof(Time)).Cast<Time>().Max();

            return (Time)random.Next(min, max + 1);
        }*/
    }

    internal static class UsersNames
    {
        public static readonly List<string> Names = new List<string>
        {
            "Misha", "Masha", "Sasha", "Zhenya", "Ruslan", "Nikita", "Lilit",
            "Yu", "Anna", "Ilya", "Elena", "Andrey", "Vasilii", "Ivan", "Peter",
            "Tanya", "Olya", "Hui"
        };
    }
}