using MediatR;
using ToDoTask.Application.Tasks.Query;

namespace ToDoTask.Api.Endpoints.Tasks;

public class GetTaskByIdEndpoint : IEndpoint
{
    public void RegisterEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/tasks/{id}", Handler).WithName("GetTaskById").WithTags("Tasks")
            .WithDisplayName("Get Task by Id");
    }

    private async Task<IResult> Handler(IMediator mediator, int id)
    {
        var query = new GetTaskByIdQuery(id);

        var result = await mediator.Send(query);


        if (result.IsError)
        {
            return Results.BadRequest(result.Errors);
        }

        return Results.Ok(result.Value);
    }
}