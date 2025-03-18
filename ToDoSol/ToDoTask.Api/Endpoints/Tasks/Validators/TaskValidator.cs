using System.Data;
using FluentValidation;
using ToDoTask.Domain;

namespace ToDoTask.Api.Endpoints.Tasks.Validators;

///this is validation class for validation
///of DoTask entity that sending as request to endpoint
public class TaskValidator : AbstractValidator<DoTask>
{
    public TaskValidator()
    {
        RuleFor(task => task.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(task => task.Title).MaximumLength(50).WithMessage("Title must not exceed 50 characters");
        RuleFor(task => task.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(task => task.DueDate).GreaterThanOrEqualTo(DateTime.Today).WithMessage("Due date cannot be greater than today");
    }
}