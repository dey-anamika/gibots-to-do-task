using System;
using System.Threading.Tasks;
using ToDoList.Services.Models;

namespace ToDoList.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly ToDoListContext ToDoListContext;

        public ToDoListService(ToDoListContext toDoListContext)
        {
            ToDoListContext = toDoListContext;
        }

        public void AddNewTask(TaskDetail task)
        {
            task.CreatedBy = task.ModifiedBy = "CurrentUser";
            task.CreatedOn = task.ModifiedOn = DateTime.Now;
            ToDoListContext.Set<TaskDetail>().Add(task);
        }

        public void UpdateTask(TaskDetail task)
        {
            task.ModifiedOn = DateTime.Now;
            ToDoListContext.Set<TaskDetail>().Update(task);
        }

        public void DeleteTask(TaskDetail task)
        {
            task.ModifiedOn = DateTime.Now;
            ToDoListContext.Set<TaskDetail>().Remove(task);
        }

        public async Task<TaskDetail> SaveAsync(TaskDetail taskDetail)
        {
            await ToDoListContext.SaveChangesAsync();
            return taskDetail;
        }
    }
}
