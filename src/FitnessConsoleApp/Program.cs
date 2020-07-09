using FitnessCore.Enums;
using FitnessCore.Managers;
using FitnessCore.Models;
using System;

namespace FitnessConsoleApp
{
     class Program
    {
        static PersonManager personManager = new PersonManager();
        static Person currentUser;
        static void Main(string[] args)
        {
            currentUser = personManager.GetFirstUser();

            Console.WriteLine("Welcome to your Fitness Tracker App!");
            while (true)
            {
                ShowMenu();
                var userInput = Console.ReadKey();
                Console.WriteLine();
                switch (userInput.Key)
                {
                    case ConsoleKey.A:
                        {
                            AddNewUser();
                        }
                        break;
                    case ConsoleKey.C:
                        {
                            ChangeUser();
                        }
                        break;
                    case ConsoleKey.S:
                        {
                            if (currentUser == null)
                            {
                                Console.WriteLine("No current user chosen.");
                            }
                            else
                            {
                                ShowStatistics();
                            }
                        }
                        break;
                    case ConsoleKey.W:
                        {
                            if (currentUser == null)
                            {
                                Console.WriteLine("No current user chosen.");
                            }
                            else
                            {
                                Workout();
                            }
                        }
                        break;
                    case ConsoleKey.U:
                        {
                            personManager.ShowAllUsers();
                        }
                        break;
                    case ConsoleKey.Q:
                        {
                            Environment.Exit(0);
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("invalid option.");
                            Console.WriteLine();
                        }
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("Choose, what you want to do:");
            Console.WriteLine("a - Add new user;");
            Console.WriteLine("c - Change current user;");
            Console.WriteLine("s - Show current user statistics;");
            Console.WriteLine("u - Show all users;");
            Console.WriteLine("w - Add new workout record;");
            Console.WriteLine("q - Quit");
        }

        static void AddNewUser()
        {
            Console.WriteLine("Enter user's information:");
            Console.Write("Name: ");
            var name = Console.ReadLine();
            Console.Write("Age: ");
            Int32.TryParse(Console.ReadLine(), out int age);
            Console.Write("Weight: ");
            Double.TryParse(Console.ReadLine(), out double weight);
            Console.Write("Height: ");
            Double.TryParse(Console.ReadLine(), out double height);
            personManager.CreateUser(name, age, weight, height);
        }

        static void ChangeUser()
        {
            Console.Write("Enter user's id: ");
            var id = Console.ReadLine();
            Person user = personManager.GetUserById(id);

            if (user == null)
            {
                Console.WriteLine("User not found.");
            }
            else
            {
                currentUser = user;
            }

        }

        static void ShowStatistics()
        {
            personManager.GetStatistics(currentUser.Id);
        }

        static void Workout()
        {
            Console.WriteLine("Choose the type of workout:");
            for (int i = 1; i < 8; i++)
            {
                Console.WriteLine($"{i} - {(ExerciseType)i},");
            }
            Int32.TryParse(Console.ReadLine(), out int userTypeInput);
            if (userTypeInput == 0)
            {
                Console.WriteLine("Invalid workout option.");
                return;
            }
            Console.WriteLine("How many hours did you exercise?");
            Double.TryParse(Console.ReadLine(), out double userHourInput);
            if (userHourInput == 0)
            {
                Console.WriteLine("Invalid time.");
                return;
            }
            personManager.DoExercise(currentUser, (ExerciseType)userTypeInput, userHourInput);
        }
    }
}
