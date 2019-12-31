using Microsoft.EntityFrameworkCore;

namespace ToDoList.Services.Models
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        {

        }

        public DbSet<TaskDetail> ToDoList { get; set; }
    }
}
