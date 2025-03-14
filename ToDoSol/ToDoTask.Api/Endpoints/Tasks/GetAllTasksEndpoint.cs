using Microsoft.AspNetCore.Http.HttpResults;
using ToDoTask.Infrastructure;

namespace ToDoTask.Api.Endpoints.Tasks;

public class GetAllTasksEndpoint : IEndpoint
{
    public void RegisterEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("api/tasks{id}", Handler);
    }

    private async Task<IResult> Handler(int id, CancellationToken cancellationToken)
    {
        
        
        return Results.Ok();   
    }
}