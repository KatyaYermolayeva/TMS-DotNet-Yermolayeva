using System;
using System.Collections.Generic;
using System.Text;

using Homework_4.Intefaces;
using Homework_4.Models;
using Homework_4.Enums;

namespace Homework_4.Managers
{
    class AnimalManager : IAnimalManager
    {
        public void Rename(Animal animal, string name)
        {
            animal.Name = name;
        }

        public void GetInfo(Animal animal)
        {
            Console.WriteLine($"ID: {animal.GetId()}");
            Console.WriteLine($"Name: {animal.Name}");
            Console.WriteLine($"Kind: {animal.Kind}");
            Console.WriteLine($"Passport: {animal.GetPassport()}");
        }

        public void SetPassport(Animal animal, string passport)
        {
            animal.SetPassport(passport);
        }

        public Animal CreateAnimal()
        {
            return new Animal();
        }

        public Animal CreateAnimal(string name)
        {
            return new Animal(name);
        }

        public Animal CreateAnimal(string name, KindType kind)
        {
            return new Animal(name, kind);
        }

        public Animal CreateAnimal(string name, KindType kind, string passport)
        {
            return new Animal(name, kind, passport);
        }
    }
}