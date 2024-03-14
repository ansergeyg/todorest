namespace ToDoRest.Api.Models;

public class ToDo
{
    public Guid Id { get; }
    public string Title {get; }
    public string Description { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public DateTime LastModifiedDateTime { get; }
    public List<string> Priority { get; }
    public List<string> Tags { get; }

    public ToDo(Guid id,
                string title,
                string description,
                DateTime startDateTime,
                DateTime endDateTime,
                DateTime lastModifiedDateTime,
                List<string> priority,
                List<string> tags)
    {
        //Enforce invariants here if needed.
        Id = id;
        Title = title;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Priority = priority;
        Tags = tags;
    }

}