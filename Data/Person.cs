#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

#endregion

namespace AaDS_Project.Data
{
    public class Person
    {
        private static int _count;
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
        private readonly List<Person> _users;

        public PersonContainer()
        {
            _users = new List<Person>();
        }

        public void GetUsers(int number)
        {
            var random = new Random();
            
            RandomizeUsers(number, random);
        }

        private void RandomizeUsers(int numberOfUsers, Random random)
        {
            for (int i = 0; i < numberOfUsers; i++)
            {
                var schedule = new Dictionary<Time, String>();
                schedule[RandomizeTime(random)] = Places.Names[random.Next(Places.Names.Count)];
                
                var name = UsersNames.Names[random.Next(UsersNames.Names.Count)];
                var person = new Person(name, schedule);
                
                _users.Add(person);
            }
        }

        private static Time RandomizeTime(Random random)
        {
            int min = (int)Enum.GetValues(typeof(Time)).Cast<Time>().Min();
            int max = (int)Enum.GetValues(typeof(Time)).Cast<Time>().Max();

            return (Time)random.Next(min, max + 1);
        }
    }
    
    public static class UsersNames
    {
        public static readonly List<string> Names = new List<string>
        {
            "Misha", "Masha", "Sasha", "Zhenya", "Ruslan", "Nikita", "Lilit",
            "Yu", "Anna", "Ilya", "Elena", "Andrey", "Vasilii", "Ivan", "Peter", 
            "Tanya", "Olya", "Hui"
        };
    }
}