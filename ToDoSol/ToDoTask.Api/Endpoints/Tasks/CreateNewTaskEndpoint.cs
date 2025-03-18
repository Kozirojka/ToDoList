using FluentValidation;
using MediatR;
using ToDoTask.Application.Tasks.Command;
using ToDoTask.Domain;

namespace ToDoTask.Api.Endpoints.Tasks;

public class CreateNewTaskEndpoint : IEndpoint
{
    public void RegisterEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/task", Handler).WithName("CreateTask").WithTags("Tasks")
            .WithDescription("Creates a new task.");
    }

    public async Task<IResult> Handler(DoTask request, IMediator mediator,
        IValidator<DoTask> validator, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }

        var command = new CreateNewTaskCommand(request);

        var result = await mediator.Send(command, cancellationToken);

        if (result.IsError)
        {
            return Results.BadRequest(result.Errors);
        }

        return Results.Ok(result.Value);
    }
    
    
}