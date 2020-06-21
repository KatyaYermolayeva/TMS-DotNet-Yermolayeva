using System;

namespace Homework_2
{
    class Program
    {
        enum Week
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        static void GetNameOfTheDay(string s)
        {
            try
            {
                int n = Convert.ToInt32(s);
                if (n >= 1 && n <= 7)
                {
                    Console.WriteLine("It's called {0}.", (Week)(n - 1));
                }
                else
                {
                    Console.WriteLine("Invalid input (number out of range).");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input (not a number).");
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter day's number (from 1 to 7): ");
            GetNameOfTheDay(Console.ReadLine());
            Console.ReadLine();
        }
    }
}
