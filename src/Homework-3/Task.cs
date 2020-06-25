using System;

namespace Homework_3
{
    [Serializable]
    public class Task
    {
        public DateTime CreationTime { get; }
        public DateTime DueToTime { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Task() : this(DateTime.Now) { }
        public Task(DateTime dueToTime, string name = "New task", string description = "")
        {
            CreationTime = DateTime.Now;
            DueToTime = dueToTime;
            Name = name;
            Description = description;
        }
        public void Show()
        {
            Console.WriteLine($"Name: {Name};\nDescription: {Description};\n" +
                $"Created: {CreationTime};\nDue to: {DueToTime}.\n");
        }
    }
}
