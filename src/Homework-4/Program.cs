using System;

using Homework_4.Models;
using Homework_4.Managers;

namespace Homework_4
{
    partial class Program
    {
        private static readonly AnimalManager _animalManager = new AnimalManager();
        private static readonly ZooManager _zoo = new ZooManager();

        static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();
                int.TryParse(Console.ReadLine(), out int userInput);
                switch (userInput)
                {
                    case 1:
                        {
                            InputAnimal();
                        }
                        break;
                    case 2:
                        {
                            Animal animal;
                            if ((animal = ChooseAnimal()) != null)
                            {
                                _zoo.Remove(animal);
                                Console.WriteLine("Животное было успешно удалено из зоопарка.");
                            }
                        }
                        break;
                    case 3:
                        {
                            Animal animal;
                            if ((animal = ChooseAnimal()) != null)
                            {
                                _zoo.GetAnimal(animal);
                            }
                        }
                            break;
                    case 4:
                        {
                            _zoo.GetAllAnimals();
                        }
                        break;
                    case 5:
                        {
                            Environment.Exit(0);
                        }
                        break;
                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Команда не найдена");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                }
                Console.WriteLine();
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить животное");
            Console.WriteLine("2. Удалить животное");
            Console.WriteLine("3. Показать животное");
            Console.WriteLine("4. Показать всех животных");
            Console.WriteLine("5. Выход");
            Console.WriteLine();
        }

        private static void InputAnimal()
        {
            Animal animal;
            Console.Write("Введите имя: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                animal = _animalManager.CreateAnimal();
            }
            else
            {
                animal = _animalManager.CreateAnimal(name);
            }
            Console.Write("Введите пасспорт: ");
            var passport = Console.ReadLine();
            if (!string.IsNullOrEmpty(passport))
            {
                animal.SetPassport(passport);
            }
            Console.WriteLine("Выберите тип животного:\n1. Хищник\n2. Травоядное");
            int.TryParse(Console.ReadLine(), out int userInput);
            switch (userInput)
            {
                case 1:
                    {
                        animal.Kind = Enums.KindType.Predator;
                    }
                    break;
                case 2:
                    {
                        animal.Kind = Enums.KindType.Herbivorous;
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Некорректный ввод данных." +
                            " Тип животного установлен как неопределенный.");
                        animal.Kind = Enums.KindType.None;
                    }
                    break;
            }
            _zoo.SetAnimal(animal);
            Console.WriteLine("Животное успешно создано и добавлено в зоопарк!");
        }

        private static Animal ChooseAnimal()
        {
            Console.Write("Введите ID животного: ");
            Animal animal;
            if (Guid.TryParse(Console.ReadLine(), out Guid id) && (animal = _zoo.GetAnimalByID(id)) != null)
            {
                return animal;
            }
            else
            {
                Console.WriteLine("Животное с таким ID не найдено.");
                return null;
            }
        }
    }
}
