namespace Todo.Domain.Entities;

using global::Todo.Domain.Common;

public class Todo: BaseEntity
{
    public string Title { get; set; }
    public string Memo { get; set; }
    public bool Done { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DueDate { get; set; }
}
