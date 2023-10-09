namespace Todo.Application.Features.Commands;

using AutoMapper;
using MediatR;
using Todo.Application.Models;
using Todo.Application.Repositories;

public class UpdateTodo: IRequest<bool>
{
    public UpdateTodoRequest TodoRequest { get; set; }
    public UpdateTodo(UpdateTodoRequest todoRequest) => TodoRequest = todoRequest;
}

public class UpdateTodoHandler : IRequestHandler<UpdateTodo, bool>
{
    private readonly ITodoRepository _repository;
    private readonly IMapper _mapper;

    public UpdateTodoHandler(ITodoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateTodo request, CancellationToken cancellationToken)
    {
        var todo = await _repository.GetByIdAsync(request.TodoRequest.Id);
        if (todo is null)
        {
            return false;
        }
        
        todo.Done = request.TodoRequest.Done;
        todo.Title = request.TodoRequest.Title;
        todo.Memo = request.TodoRequest.Memo;
        todo.StartDate = request.TodoRequest.StartDate;
        todo.DueDate = request.TodoRequest.DueDate;
        
        await _repository.UpdateAsync(todo);
        return true;
    }
}
