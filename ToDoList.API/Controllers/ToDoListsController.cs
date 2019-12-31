using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Services;
using ToDoList.Services.Models;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private readonly ToDoListContext _context;

        private readonly IToDoListService _service;

        public ToDoListsController(ToDoListContext context, IToDoListService toDoListService)
        {
            _context = context;
            _service = toDoListService;
        }

        [HttpGet("status/{status}")]
        public IEnumerable<TaskDetail> GetTasksByStatus(Services.TaskStatus status)
        {
            return _context.ToDoList.Where(s => s.Status == status);
        }

        [HttpGet("{id}")]
        public TaskDetail GetTaskDetail(int id)
        {
            var taskDetail = _context.ToDoList.Where(s => s.Id == id).FirstOrDefault();

            if (taskDetail == null)
            {
                throw new Exception("No task found");
            }

            return taskDetail;
        }

        [HttpPut("{id}")]
        public int PutTaskDetail(int id, Services.TaskDetail taskDetail)
        {
            if (id != taskDetail.Id)
            {
                return 0;
            }
            _service.UpdateTask(taskDetail);
            return _service.SaveAsync(taskDetail).Id;
        }

        [HttpPost]
        public int PostTaskDetail([FromBody] Services.TaskDetail taskDetail)
        {
            _service.AddNewTask(taskDetail);
            return _service.SaveAsync(taskDetail).Id;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Services.TaskDetail>> DeleteTaskDetail(int id)
        {
            var taskDetail = await _context.ToDoList.FindAsync(id);
            if (taskDetail == null)
            {
                return NotFound();
            }

            _context.ToDoList.Remove(taskDetail);
            await _context.SaveChangesAsync();

            return taskDetail;
        }
    }
}
