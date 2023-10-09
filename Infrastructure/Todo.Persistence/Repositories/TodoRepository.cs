namespace Todo.Persistence.Repositories;

using Todo.Application.Repositories;
using Todo.Domain.Entities;
using Todo.Persistence.Contexts;

public class TodoRepository: ITodoRepository
{
    private readonly TodoDbContext _context;
    public TodoRepository(TodoDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Todo todo)
    {
        await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync();
    }

    public Task UpdateAsync(Todo todo) => throw new NotImplementedException();

    public Task DeleteAsync(Guid id) => throw new NotImplementedException();

    public Task<Todo?> GetByIdAsync(Guid id) => throw new NotImplementedException();

    public Task<IEnumerable<Todo>> GetAllAsync() => throw new NotImplementedException();
}
