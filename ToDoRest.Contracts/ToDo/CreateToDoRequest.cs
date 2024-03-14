namespace ToDoRest.Contracts;

public record CreateToDoRequest
(
    string Title,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Priority,
    List<string> Tags
);