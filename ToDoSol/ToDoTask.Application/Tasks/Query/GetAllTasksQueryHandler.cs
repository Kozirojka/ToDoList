using ErrorOr;
using MediatR;
using ToDoTask.Domain;
using ToDoTask.Infrastructure;

namespace ToDoTask.Application.Tasks.Query;

public record GetAllTasksQuery() : IRequest<ErrorOr<List<DoTask>>>;

public class GetAllTasksQueryHandler(TaskRepository repository) : IRequestHandler<GetAllTasksQuery, ErrorOr<List<DoTask>>>
{
    public async Task<ErrorOr<List<DoTask>>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        
        var listOfTasks = repository.GetAll().ToList();

        if (listOfTasks.Count == 0)
        {
            return Error.NotFound("Tasks.NotFound", "There is not tasks"); 
        }
        
        return listOfTasks;
        
    }
}