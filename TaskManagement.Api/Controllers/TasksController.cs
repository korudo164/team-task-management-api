using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Api.Data;
using TaskManagement.Api.Models;

namespace TaskManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
  private  readonly AppDbContext _context;
  public TasksController(AppDbContext context) => _context = context;

  // GET: api/tasks
  [HttpGet]
  public async Task<ActionResult<IEnumerable<TaskItem>>> GetAll() => await _context.TaskItems.ToListAsync();

  // GET: api/tasks/5
  [HttpGet("{id}")]
  public async Task<ActionResult<TaskItem>> GetById(int id)
  {
    var task = await _context.TaskItems.FindAsync(id);
    if (task == null) return NotFound();
    return task;
  }

  // POST: api/tasks
  [HttpPost]
  public async Task<ActionResult<TaskItem>> Create(TaskItem task)
  {
    _context.TaskItems.Add(task);
    await _context.SaveChangesAsync();
    return CreatedAtAction(nameof(GetById), new {id = task.Id }, task);
  }

  // PUT: api/tasks/5
  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, TaskItem task)
  {
    if (id != task.Id) return BadRequest();
    _context.Entry(task).State = EntityState.Modified;
    await _context.SaveChangesAsync();
    return NoContent();
  }

  // DELETE: api/tasks/5
  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    var task = await _context.TaskItems.FindAsync(id);
    if (task == null) return NotFound();
    _context.TaskItems.Remove(task);
    await _context.SaveChangesAsync();
    return NoContent();
  }
}