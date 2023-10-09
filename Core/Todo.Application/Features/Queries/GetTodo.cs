namespace Todo.Application.Features.Queries;

using AutoMapper;
using MediatR;
using Todo.Application.Models;
using Todo.Application.Repositories;

public class GetTodo: IRequest<TodoDto>
{
   public Guid Id { get; set; }
   public GetTodo(Guid id) => Id = id;
}

public class FindTodoHandler : IRequestHandler<GetTodo, TodoDto>
{
   private readonly ITodoRepository _todoRepository;
   private readonly IMapper _mapper;
   public FindTodoHandler(ITodoRepository todoRepository, IMapper mapper)
   {
      _todoRepository = todoRepository;
      _mapper = mapper;
   }

   public async Task<TodoDto> Handle(GetTodo request, CancellationToken cancellationToken)
   {
      var todo = await _todoRepository.GetByIdAsync(request.Id);
      var todoDto = _mapper.Map<TodoDto>(todo);
      return todoDto;
   }
}
