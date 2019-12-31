using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Services
{
    public enum TaskStatus
    {
        New = 0,
        InProgress,
        OnHalt,
        Completed
    }

    public enum Priority
    {
        Low = 0,
        Mid,
        High
    }
}
