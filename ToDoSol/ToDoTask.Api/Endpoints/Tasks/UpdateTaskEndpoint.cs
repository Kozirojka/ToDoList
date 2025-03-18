using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoTask.Application.Tasks.Command;

namespace ToDoTask.Api.Endpoints.Tasks;

public class UpdateTaskEndpoint : IEndpoint
{
    public void RegisterEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPut("/api/tasks/{id}", Handler).WithName("UpdateTask").WithTags("Tasks")
            .WithDescription("Updates a task");
    }

    private async Task<IResult> Handler([FromBody] Domain.ToDoTask request, [FromRoute] int id,
        CancellationToken cancellationToken, IMediator mediator, IValidator<Domain.ToDoTask> validator)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }

        var command = new UpdateTaskCommand(request, id);
        var result = await mediator.Send(command, cancellationToken);

        if (result.IsError)
        {
            return Results.BadRequest(result.Errors);
        }

        return Results.Ok(result.Value);
    }
}