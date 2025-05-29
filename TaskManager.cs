using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList2
{
   public class TaskManager
    {
        private LinkedList<Task> toDoTasks = new LinkedList<Task>();
        private Stack<Task> inProgressTasks = new Stack<Task>();
        private Queue<Task> completedTasks = new Queue<Task>();

        public void AddToDoTask(Task task)
        {
            if (toDoTasks.Count == 0)
            {
                toDoTasks.AddFirst(task);
            }
            else
            {
                var current = toDoTasks.First;
                while (current != null && current.Value.Date <= task.Date)
                {
                    current = current.Next;
                }

                if (current == null)
                    toDoTasks.AddLast(task);
                else
                    toDoTasks.AddBefore(current, task);
            }
        }

        public void MoveToInProgress(int taskId)
        {
            var node = toDoTasks.First;
            while (node != null)
            {
                if (node.Value.ID == taskId)
                {
                    Task task = node.Value;
                    toDoTasks.Remove(node);
                    task.Status = TaskStatus.InProgress;
                    inProgressTasks.Push(task);
                    Console.WriteLine($"Moved to In Progress: {task}");
                    return;
                }
                node = node.Next;
            }
            Console.WriteLine("Task not found in ToDo list.");
        }

        public void CompleteTask()
        {
            if (inProgressTasks.Count == 0)
            {
                Console.WriteLine("No tasks in progress.");
                return;
            }

            Task task = inProgressTasks.Pop();
            task.Status = TaskStatus.Completed;
            completedTasks.Enqueue(task);
            Console.WriteLine($"Task completed: {task}");
        }

        public void DisplayAll()
        {
            Console.WriteLine("\nTo Do Tasks:");
            foreach (var task in toDoTasks) Console.WriteLine(task);

            Console.WriteLine("\nIn Progress Tasks:");
            foreach (var task in inProgressTasks) Console.WriteLine(task);

            Console.WriteLine("\nCompleted Tasks:");
            foreach (var task in completedTasks) Console.WriteLine(task);
        }
    }
}

