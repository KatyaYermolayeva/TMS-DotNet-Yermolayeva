using System;
using System.Collections.Generic;
using System.Text;

using Homework_4.Enums;

namespace Homework_4.Models
{
    class Animal
    {
        private readonly Guid _id = Guid.NewGuid();
        private string _passport;

        public Animal()
        {
            Name = "No name";
            Kind = KindType.None;
            _passport = Guid.NewGuid().ToString();
        }

        public Animal(string name)
        {
            Name = name;
            Kind = KindType.None;
            _passport = Guid.NewGuid().ToString();
        }

        public Animal(string name, KindType kind)
        {
            Name = name;
            Kind = kind;
            _passport = Guid.NewGuid().ToString();
        }

        public Animal(string passport, string name, KindType kind)
        {
            Name = name;
            Kind = kind;
            _passport = passport;
        }

        public string Name { get; set; }
        
        public KindType Kind { get; set; }
       
        public string GetPassport()
        {
            return _passport;
        }
       
        public Guid GetId()
        {
            return _id;
        }
        
        public void SetPassport(string passport)
        {
            _passport = passport;
        }
    }
}
