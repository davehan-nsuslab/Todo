namespace Todo.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
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

    public async Task<Todo?> GetByIdAsync(Guid id)
    {
        return await _context.Todos.FindAsync(id);
    }

    public async Task<IEnumerable<Todo>> GetAllAsync()
    {
        return await _context.Todos.ToListAsync();
    }
}
