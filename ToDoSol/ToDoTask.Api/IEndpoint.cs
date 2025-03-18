namespace ToDoTask.Api;

// this interface will inherit class for
// creating and automatically mapping the endpoint 
public interface IEndpoint
{
    void RegisterEndpoints(IEndpointRouteBuilder endpoints);
}