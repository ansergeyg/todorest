namespace ToDoRest.Api.Services;

using ToDoRest.Api.Models;

public interface IToDoService
{
    void CreateToDo(ToDo todo);
    void DeleteToDo(Guid id);
    ToDo GetToDo(Guid id);
    void UpdateToDo(ToDo todo);
}