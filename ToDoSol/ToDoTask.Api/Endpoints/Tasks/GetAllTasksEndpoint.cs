using FluentValidation;
using MediatR;
using ToDoTask.Api.Extension;
using ToDoTask.Application.Tasks.Query;

namespace ToDoTask.Api.Endpoints.Tasks;

/// <summary>
/// This is first created endpoint using minimal api, mediatR
/// Endpoint exist for purpose to fetch all tasks
/// </summary>
public class GetAllTasksEndpoint : IEndpoint
{
    public void RegisterEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("api/tasks", Handler).WithName("GetAllTask").WithTags("Tasks")
            .WithDisplayName("Get all tasks");
    }

    private async Task<IResult> Handler(
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        var query = new GetAllTasksQuery();

        var result = await mediator.Send(query, cancellationToken);

        if (result.IsError)
        {
            return result.Errors.ToProblem();
        }

        return Results.Ok(result.Value);
    }
}