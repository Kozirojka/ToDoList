using System.Data;
using FluentValidation;

namespace ToDoTask.Api.Endpoints.Tasks.Validators;

public class TaskValidator : AbstractValidator<Domain.ToDoTask>
{
    public TaskValidator()
    {
        RuleFor(task => task.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(task => task.Title).MaximumLength(50).WithMessage("Title must not exceed 100 characters");
        RuleFor(task => task.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(task => task.DueDate).GreaterThanOrEqualTo(DateTime.Today);
    }
}

/*
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; private set; }
 */