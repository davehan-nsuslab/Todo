namespace Todo.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

public class TodoDbContext: DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options): base(options)
    {
    }

    public DbSet<Todo> Todos => Set<Todo>();
}
