using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList2
{
    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Completed
    }
    public class Task
    {
        public string TaskName { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TaskStatus Status { get; set; }

        public Task(string taskName, int id, string description, DateTime date)
        {
            TaskName = taskName;
            ID = id;
            Description = description;
            Date = date;
            Status = TaskStatus.ToDo;
        }

        public override string ToString()
        {
            return $"[{ID}] {TaskName} - {Status} - {Date.ToShortDateString()}";
        }
    }
}
