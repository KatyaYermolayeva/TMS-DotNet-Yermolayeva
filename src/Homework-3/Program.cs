using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Homework_3
{
    class Program
    {
        static List<Task> toDoList;
        static void ViewList()
        {
            for (int i = 0; i < toDoList.Count; i++)
            {
                Console.WriteLine($"Task {i + 1}");
                toDoList[i].Show();
            }
        }
        static void AddTask()
        {
            var task = new Task();
            Console.Write("Enter task's information:\nName: ");
            task.Name = Console.ReadLine();
            Console.Write("Description: ");
            task.Description = Console.ReadLine();
            Console.Write("Due to time: ");
            DateTime dueToTime;
            if (!DateTime.TryParse(Console.ReadLine(), out dueToTime))
            {
                dueToTime = DateTime.Now.AddDays(1);
                Console.WriteLine("Invalid date format. Task is set due tomorrow.");
            }
            task.DueToTime = dueToTime;
            toDoList.Add(task);
        }
        static void DeleteTask()
        {
            Console.Write("Enter a number of task to delete: ");
            int i;
            if (!Int32.TryParse(Console.ReadLine(), out i))
            {
                Console.WriteLine("Invalid input (not a number).");
            }
            else if (i <= 0 || i > toDoList.Count)
            {
                Console.WriteLine("Invalid input (index out of range).");
            }
            else
            {
                toDoList.RemoveAt(i - 1);
            }
        }
        static void EditTask()
        {
            Console.Write("Enter a number of task to edit: ");
            int i;
            if (!Int32.TryParse(Console.ReadLine(), out i))
            {
                Console.WriteLine("Invalid input (not a number).");
            }
            else if (i <= 0 || i > toDoList.Count)
            {
                Console.WriteLine("Invalid input (index out of range).");
            }
            else
            {
                Console.WriteLine("Choose what to edit: n - name; d - description, t - due to time.");
                ConsoleKeyInfo choice = Console.ReadKey();
                Console.WriteLine();
                switch (choice.Key)
                {
                    case ConsoleKey.N:
                        {
                            Console.Write("Enter task's new name: ");
                            toDoList[i - 1].Name = Console.ReadLine();
                            break;
                        }
                    case ConsoleKey.D:
                        {
                            Console.Write("Enter task's new description: ");
                            toDoList[i - 1].Description = Console.ReadLine();
                            break;
                        }
                    case ConsoleKey.T:
                        {
                            Console.Write("Enter task's new due to time: ");
                            DateTime dueToTime;
                            if (DateTime.TryParse(Console.ReadLine(), out dueToTime))
                            {
                                toDoList[i - 1].DueToTime = dueToTime;
                            }
                            else
                            {
                                Console.WriteLine("Invalid date format. Task's due to time remains the same.");
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid input.");
                            break;
                        }
                }
            }
        }
        static void Main(string[] args)
        {
            
            try
            {
                using (FileStream fs = new FileStream("list.dat", FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    toDoList = (List<Task>)bf.Deserialize(fs);
                }
            }
            catch (Exception)
            {
                toDoList = new List<Task>();
            }

            Console.WriteLine("Welcome to your To-do list!");
            bool isWorking = true;
            while (isWorking)
            {
                Console.WriteLine("Choose what you want to do: " +
                    "v - view the list; a - add new task; e - edit a task; d - delete a task; c - close.");
                ConsoleKeyInfo choice = Console.ReadKey();
                Console.WriteLine();
                switch (choice.Key)
                {
                    case ConsoleKey.V:
                        {
                            ViewList();
                            break;
                        }
                    case ConsoleKey.A:
                        {
                            AddTask();
                            break;
                        }
                    case ConsoleKey.E:
                        {
                            EditTask();
                            break;
                        }
                    case ConsoleKey.D:
                        {
                            DeleteTask();
                            break;
                        }
                    case ConsoleKey.C:
                        {
                            isWorking = false;
                            break;
                        }
                }
            }

            using (FileStream fs = new FileStream("list.dat", FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, toDoList);
            }
            Console.ReadLine();
        }
    }
}
