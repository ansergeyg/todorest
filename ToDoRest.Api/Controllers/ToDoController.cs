namespace ToDoRest.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using ToDoRest.Api.Models;
using ToDoRest.Api.Services;
using ToDoRest.Contracts;

[ApiController]
[Route("todo")]
public class ToDoController : ControllerBase
{
    //DI
    private IToDoService _toDoService;
    public ToDoController(IToDoService toDoService)
    {
        _toDoService = toDoService;
    }

    [HttpPost]
    public IActionResult CreateToDo(CreateToDoRequest toDoRequest)
    {
        ToDo todo = new ToDo(
            Guid.NewGuid(),
            toDoRequest.Title,
            toDoRequest.Description,
            toDoRequest.StartDateTime,
            toDoRequest.EndDateTime,
            DateTime.Now,
            toDoRequest.Priority,
            toDoRequest.Tags
        );
        
        _toDoService.CreateToDo(todo);

        ToDoResponse response = new ToDoResponse(
            todo.Id,
            todo.Title,
            todo.Description,
            todo.StartDateTime,
            todo.EndDateTime,
            todo.LastModifiedDateTime,
            todo.Priority,
            todo.Tags
        );

        return CreatedAtAction(nameof(GetToDo), new { id = todo.Id }, response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetToDo(Guid id)
    {
        ToDo todo = _toDoService.GetToDo(id);

        ToDoResponse response = new ToDoResponse(
            todo.Id,
            todo.Title,
            todo.Description,
            todo.StartDateTime,
            todo.EndDateTime,
            todo.LastModifiedDateTime,
            todo.Priority,
            todo.Tags 
        );

        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateToDo(Guid id, UpdateToDoRequest toDoRequest)
    {
        ToDo todo = new ToDo(
            id,
            toDoRequest.Title,
            toDoRequest.Description,
            toDoRequest.StartDateTime,
            toDoRequest.EndDateTime,
            DateTime.Now,
            toDoRequest.Priority,
            toDoRequest.Tags
        );

        _toDoService.UpdateToDo(todo);

        // TODO: return 201 if a new todo was created
        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    public IActionResult DeletedToDo(Guid id)
    {
        _toDoService.DeleteToDo(id);
        return Ok(id);
    }
}