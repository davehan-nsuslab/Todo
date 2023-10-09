namespace Todo.Application.Features.Validators;

using FluentValidation;
using Todo.Application.Models;

public class CreateTodoValidator: AbstractValidator<CreateTodoRequest>
{
    public CreateTodoValidator()
    {
        RuleFor(t => t.Title)
           .NotEmpty()
           .WithMessage("The title cannot be empty")
           .MinimumLength(5)
           .WithMessage("The title must be at least 5 characters long")
           .MaximumLength(100)
           .WithMessage("The title cannot be longer than 100 characters");
        RuleFor(t => t.Memo)
           .NotEmpty()
           .WithMessage("The memo cannot be empty")
           .MinimumLength(5)
           .WithMessage("The memo must be at least 5 characters long")
           .MaximumLength(4000)
           .WithMessage("The memo cannot be longer than 4000 characters");
        RuleFor(t => t.DueDate)
           .NotEmpty()
           .WithMessage("The due date cannot be empty")
           .GreaterThanOrEqualTo(DateTime.Now)
           .WithMessage("The due date cannot be in the past");
    }
}
