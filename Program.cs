using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList2
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager manager = new TaskManager();

            manager.AddToDoTask(new Task("Design UI", 1, "Design login UI", new DateTime(2025, 6, 1)));
            manager.AddToDoTask(new Task("Write API", 2, "Develop backend", new DateTime(2025, 5, 30)));
            manager.AddToDoTask(new Task("Testing", 3, "Unit testing", new DateTime(2025, 6, 5)));

            manager.DisplayAll();

            manager.MoveToInProgress(2);
            manager.MoveToInProgress(1);

            manager.DisplayAll();

            manager.CompleteTask();

            manager.DisplayAll();
        }
    }
}
