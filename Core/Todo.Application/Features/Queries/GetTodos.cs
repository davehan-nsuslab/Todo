namespace Todo.Application.Features.Queries;

using AutoMapper;
using MediatR;
using Todo.Application.Models;
using Todo.Application.Repositories;

public class GetTodos: IRequest<IEnumerable<TodoDto>>
{
}

public class GetTodosHandler : IRequestHandler<GetTodos, IEnumerable<TodoDto>>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IMapper _mapper;
    public GetTodosHandler(IMapper mapper, ITodoRepository todoRepository)
    {
        _mapper = mapper;
        _todoRepository = todoRepository;
    }

    public async Task<IEnumerable<TodoDto>> Handle(GetTodos request, CancellationToken cancellationToken)
    {
        var todos = await _todoRepository.GetAllAsync();
        var todosDto = _mapper.Map<IEnumerable<TodoDto>>(todos.Take(2));
        
        return todosDto;
    }
}
