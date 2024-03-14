namespace ToDoRest.Contracts;

public record ToDoResponse
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