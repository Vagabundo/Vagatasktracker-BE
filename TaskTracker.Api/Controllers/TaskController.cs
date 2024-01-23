using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.API.DTOs;
using TaskTracker.API.MappingProfiles;
using TaskTracker.Application.Interfaces;
using TaskTracker.Domain;


namespace TaskTracker.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{

    private ITaskService _taskService;
    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskDTO>>> Get()
    {
        return (await _taskService.GetAll()).Select(Mapper.Map<DeskTask, TaskDTO>).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskDTO>> Get(int id)
    {
        var entity = await _taskService.Get(id);
        if (entity == null)
        {
            return NotFound();
        }
        return Mapper.Map<DeskTask, TaskDTO>(entity);
    }

    [HttpPost]
    public async Task<ActionResult<TaskDTO>> Post(TaskDTO entity)
    {
        await _taskService.Add(Mapper.Map<TaskDTO, DeskTask>(entity));
        return CreatedAtAction("Get", new { id = entity.Id }, entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, TaskDTO entity)
    {
        if (id != entity.Id)
        {
            return BadRequest();
        }
        await _taskService.Update(Mapper.Map<TaskDTO, DeskTask>(entity));
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<TaskDTO>> Delete(int id)
    {
        var entity = await _taskService.Delete(id);
        if (entity == null)
        {
            return NotFound();
        }
        return Mapper.Map<DeskTask, TaskDTO>(entity);
    }
}