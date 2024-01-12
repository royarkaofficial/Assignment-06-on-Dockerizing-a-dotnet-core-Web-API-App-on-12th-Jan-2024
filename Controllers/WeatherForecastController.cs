using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private static List<TaskModel> tasks = new List<TaskModel>
    {
        new TaskModel { Id = 1, Title = "Task 1", Description = "Description 1" },
        new TaskModel { Id = 2, Title = "Task 2", Description = "Description 2" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<TaskModel>> Get()
    {
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public ActionResult<TaskModel> Get(int id)
    {
        var task = tasks.Find(t => t.Id == id);
        if (task == null)
            return NotFound();

        return Ok(task);
    }

    [HttpPost]
    public ActionResult<TaskModel> Post([FromBody] TaskModel task)
    {
        task.Id = tasks.Count + 1;
        tasks.Add(task);
        return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public ActionResult<TaskModel> Put(int id, [FromBody] TaskModel updatedTask)
    {
        var task = tasks.Find(t => t.Id == id);
        if (task == null)
            return NotFound();

        task.Title = updatedTask.Title;
        task.Description = updatedTask.Description;
        return Ok(task);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var task = tasks.Find(t => t.Id == id);
        if (task == null)
            return NotFound();

        tasks.Remove(task);
        return NoContent();
    }
}

public class TaskModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}
