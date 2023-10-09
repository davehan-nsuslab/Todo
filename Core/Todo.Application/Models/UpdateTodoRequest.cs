namespace Todo.Application.Models;

public class UpdateTodoRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Memo { get; set; }
    public bool Done { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DueDate { get; set; }
}
