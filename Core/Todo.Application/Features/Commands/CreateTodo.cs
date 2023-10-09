namespace Todo.Application.Features.Commands;

using AutoMapper;
using MediatR;
using Todo.Application.Models;
using Todo.Application.Repositories;
using Todo.Domain.Entities;

public class CreateTodo: IRequest<Guid>
{
    public CreateTodoRequest TodoRequest { get; set; }
    public CreateTodo(CreateTodoRequest todoRequest) => TodoRequest = todoRequest;
}

public class CreateTodoHandler : IRequestHandler<CreateTodo, Guid>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;
    public CreateTodoHandler(IMapper mapper, ITodoRepository todoRepository)
    {
        _mapper = mapper;
        _todoRepository = todoRepository;
    }

    public async Task<Guid> Handle(CreateTodo request, CancellationToken cancellationToken)
    {
        var todo = _mapper.Map<Todo>(request.TodoRequest);
        todo.Id = Guid.NewGuid();
        todo.CreatedAt = DateTime.UtcNow;
        await _todoRepository.CreateAsync(todo);

        return todo.Id;
    }
}
