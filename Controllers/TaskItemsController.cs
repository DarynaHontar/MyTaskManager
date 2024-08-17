using Microsoft.AspNetCore.Mvc;
using MyTaskManager.Models;
using MyTaskManager.Services;

namespace MyTaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {

        private readonly ITaskItemService taskItemService;
        public TaskItemsController(ITaskItemService taskItemService)
        {
            this.taskItemService = taskItemService;
        }

        [HttpGet]
        public ActionResult GetTaskItems()
        {
            var tasks = taskItemService.GetTaskItems();
            return tasks.Count > 0 ? Ok(tasks) : StatusCode(204);
        }

        [HttpPost]
        public ActionResult AddTaskItem([FromBody] CreateTaskItemRequest request)
        {
            if (request == null) return StatusCode(204);
            taskItemService.AddTaskItem(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTaskItem(int id)
        {
            bool result = taskItemService.DeleteTaskItem(id);
            if (result == false) return StatusCode(204);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateTaskItem(int id, [FromBody] CreateTaskItemRequest request)
        {
            var task = taskItemService.UpdateTaskItem(id, request);
            if (task == null) return StatusCode(204);
            return Ok(task);
        }

        [HttpGet("{id}")]
        public ActionResult GetTaskItemById([FromRoute] int id)
        {
            var task = taskItemService.GetTaskItemById(id);
            if (task == null) return StatusCode(204);
            return Ok(task);
        }
    }
}