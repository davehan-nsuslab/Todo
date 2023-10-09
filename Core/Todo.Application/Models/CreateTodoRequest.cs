namespace Todo.Application.Models;

public class CreateTodoRequest
{
    public string Title { get; set; }
    public string Memo { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DueDate { get; set; }
}
