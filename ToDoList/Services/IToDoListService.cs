using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Services
{
    public interface IToDoListService
    {
        void AddNewTask(TaskDetail task);
        void UpdateTask(TaskDetail task);
        void DeleteTask(TaskDetail task);
        Task<TaskDetail> SaveAsync(TaskDetail taskDetail);
    }
}
