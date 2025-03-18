using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoTask.Application.Tasks.Command;

namespace ToDoTask.Api.Endpoints.Tasks;

public class DeleteTaskById : IEndpoint
{
    public void RegisterEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapDelete("/api/delete/{id}", Handler).WithName("DeleteTaskById").WithTags("Tasks")
            .WithDescription("Deletes a task");
    }

    private async Task<IResult> Handler([FromRoute] int id, IMediator mediator)
    {
        var command = new DeleteTaskByIdCommand(id);
        var result = await mediator.Send(command);

        if (result.IsError)
        {
            return Results.BadRequest(result.Errors);
        }

        return Results.Ok(result.Value);
    }
}