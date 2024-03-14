namespace ToDoRest.Api.Services;

using ToDoRest.Api.Models;

public class ToDoService : IToDoService
{
    private static readonly Dictionary<Guid, ToDo> _todos = new();
    public void CreateToDo(ToDo todo)
    {
        _todos.Add(todo.Id, todo);
    }

    public void DeleteToDo(Guid id)
    {
        _todos.Remove(id);
    }

    public ToDo GetToDo(Guid id)
    {
        return _todos[id];
    }

    public void UpdateToDo(ToDo todo)
    {
        _todos[todo.Id] = todo;
    }
}