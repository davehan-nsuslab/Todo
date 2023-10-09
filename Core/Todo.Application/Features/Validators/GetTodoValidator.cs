namespace Todo.Application.Features.Validators;

using FluentValidation;
using Todo.Application.Features.Queries;

public class GetTodoValidator: AbstractValidator<GetTodo>
{
    public GetTodoValidator()
    {
        RuleFor(t => t.Id)
           .NotEmpty()
           .WithMessage("The id cannot be empty");
    }
}
