using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private static readonly List<TaskItem> _tasks = new();

    [HttpGet]
    public IActionResult GetAll() => Ok(_tasks);

    [HttpPost]
    public IActionResult Create([FromBody] TaskItem task)
    {
        task.Id = _tasks.Count + 1;
        _tasks.Add(task);
        return CreatedAtAction(nameof(GetAll), task);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task is null) return NotFound();
        _tasks.Remove(task);
        return NoContent();
    }
}