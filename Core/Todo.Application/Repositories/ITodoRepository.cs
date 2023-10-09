namespace Todo.Application.Repositories;

using Todo.Domain.Entities;

public interface ITodoRepository
{
    Task CreateAsync(Todo todo);
    Task UpdateAsync(Todo todo);
    Task DeleteAsync(Guid id);
    Task<Todo?> GetByIdAsync(Guid id);
    Task<IEnumerable<Todo>> GetAllAsync();
}
