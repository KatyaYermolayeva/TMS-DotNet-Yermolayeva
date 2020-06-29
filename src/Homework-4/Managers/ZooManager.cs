using System;
using System.Collections.Generic;
using System.Text;

using Homework_4.Models;

namespace Homework_4.Managers
{
    class ZooManager
    {
        private readonly AnimalManager _animalManager;
        List<Animal> animals = new List<Animal>();

        public ZooManager()
        {
            _animalManager = new AnimalManager();
        }

        public void GetAnimal(Animal animal)
        {
            _animalManager.GetInfo(animal);
        }

        public Animal GetAnimalByID(Guid id)
        {
            return animals.Find(x => x.GetId() == id);
        }

        public void GetAllAnimals()
        {
            if (animals.Count > 0)
            {
                foreach (var animal in animals)
                {
                    GetAnimal(animal);
                }
            }
            else
            {
                Console.WriteLine("Животных в зоопарке нет.");
            }
        }

        public void SetAnimal(Animal animal)
        {
            animals.Add(animal);
        }

        public void Remove(Animal animal)
        {
            animals.Remove(animal);
        }
    }
}