using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessCore.Models
{
    public class Person
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public int Age { get; set; }

        public IList<Result> CaloriesPerDay { get; set; } = new List<Result>();

        public Person()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
