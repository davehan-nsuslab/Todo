namespace Todo.Application.Models;

public class TodoDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Memo { get; set; }
    public bool Done { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DueDate { get; set; }
}
