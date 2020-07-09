using FitnessCore.Enums;
using FitnessCore.Interfaces;
using FitnessCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessCore.Managers
{
    public class PersonManager : IPersonManager
    {
        private readonly IList<Person> _people;
        private readonly IExerciseManager _exerciseManager;
        public PersonManager()
        {
            _people = new List<Person>();
            _exerciseManager = new ExerciseManager();

        }
        public string CreateUser(string name, int age, double weight, double height)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Invalid argument - name.");
                return null;
            }
            if (age < 10 || age > 80)
            {
                Console.WriteLine("Invalid argument - age.");
                return null;
            }
            if (weight > 250 || weight < 20)
            {
                Console.WriteLine("Invalid argument - weight.");
                return null;
            }
            if (height > 250 || height < 100)
            {
                Console.WriteLine("Invalid argument - height.");
                return null;
            }
            Person person = new Person()
            {
                Name = name,
                Age = age,
                Weight = weight,
                Height = height
            };
            _people.Add(person);
            return person.Id;
        }

        public void DoExercise(Person person, ExerciseType type, double hours)
        {
            if (person == null)
            {
                throw new ArgumentNullException("Person argument is null");
            }
            if (_people.FirstOrDefault(p => p == person) == null)
            {
                Console.WriteLine("User not found.");
                return;
            }
            var result = new Result
            {
                Date = DateTime.Now,
                Type = type,
                Calories = _exerciseManager.Exercise(type, hours, person.Weight)
            };

            person.CaloriesPerDay.Add(result);
        }

        public void GetStatistics(string id)
        {
            var person = _people.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.WriteLine($"Id: {person.Id}, Name: {person.Name}, Age: {person.Age}, " +
                   $"Weight: {person.Weight}, Height: {person.Height}.\n");
            foreach (var info in person.CaloriesPerDay)
            {
                Console.WriteLine($"Date: {info.Date}, Exercise: {info.Type}, Calories: {info.Calories}");
            }
        }

        public void ShowAllUsers()
        {
            if (_people.Count == 0)
            {
                Console.WriteLine("There are no users in the list.");
                return;
            }
            foreach (var user in _people)
            {
                Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Age: {user.Age}, " +
                    $"Weight: {user.Weight}, Height: {user.Height}.");
            }
        }

        public Person GetUserById(string id)
        {
            return _people.FirstOrDefault(p => p.Id == id);
        }

        public Person GetFirstUser()
        {
            return _people.Count == 0 ? null : _people.ElementAt(0);
        }
    }
}