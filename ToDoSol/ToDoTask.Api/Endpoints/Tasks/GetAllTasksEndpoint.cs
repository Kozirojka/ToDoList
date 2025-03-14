using Microsoft.AspNetCore.Http.HttpResults;

namespace ToDoTask.Api.Endpoints.Tasks;

public class GetAllTasksEndpoint : IEndpoint
{
    public void RegisterEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("api/tasks", Handler);
    }

    private async Task<IResult> Handler(HttpContext context)
    {
        
        
        
        
        return Results.Ok();   
    }
}