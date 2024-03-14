namespace ToDoRest.Contracts;

public record UpdateToDoRequest
(
    Guid Id,
    string Title,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    DateTime LastModifiedDateTime,
    List<string> Priority,
    List<string> Tags
);