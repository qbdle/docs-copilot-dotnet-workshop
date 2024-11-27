using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller {
  [Route("task")]
  public class TaskController : ControllerBase {
    private static List<TodoTask> tasks = new List<TodoTask>();

    [HttpGet]
    public IActionResult GetTasks() {
      // Return all tasks
      return Ok(tasks);
    }

    [HttpPost]
    public IActionResult AddTask([FromBody] TodoTask task) {
      // Check if task is null
      if (task == null) {
        // Return bad request
        return BadRequest("Invalid task");
      }

      // Check if task id and task title are empty
      if (task.Id == 0 || string.IsNullOrEmpty(task.Title)) {
        // Return bad request
        return BadRequest("Invalid task id or title");
      }

      // Test if task id is already in use
      if (tasks.Any(t => t.Id == task.Id)) {
        // Return bad request
        return BadRequest("Task id already in use");
      }

      // Add task to list
      tasks.Add(task);

      // Return all tasks
      return Ok(tasks);
    }

    // TODO Task 6
  }
}