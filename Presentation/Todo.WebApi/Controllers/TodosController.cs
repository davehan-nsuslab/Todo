namespace Todo.WebApi.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Features.Commands;
using Todo.Application.Features.Queries;
using Todo.Application.Models;

[Route("api/[controller]")]
[ApiController]
public class TodosController: ControllerBase
{
    private readonly ISender _mediator;
    
    public TodosController(ISender mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var todos = await _mediator.Send(new GetTodos());
        return Ok(todos);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var todo = await _mediator.Send(new GetTodo(id));
        return Ok(todo);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateTodoRequest todoRequest)
    {
        var id = await _mediator.Send(new CreateTodo(todoRequest));
        return Ok(id);
    }
}
