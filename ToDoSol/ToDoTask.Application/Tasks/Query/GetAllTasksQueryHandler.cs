using ErrorOr;
using MediatR;
using ToDoTask.Infrastructure;

namespace ToDoTask.Application.Tasks.Query;

public record GetAllTasksQuery() : IRequest<ErrorOr<List<Domain.ToDoTask>>>;

public class GetAllTasksQueryHandler(TaskRepository repository) : IRequestHandler<GetAllTasksQuery, ErrorOr<List<Domain.ToDoTask>>>
{
    public async Task<ErrorOr<List<Domain.ToDoTask>>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        
        var listOfTasks = repository.GetAll().ToList();

        if (listOfTasks.Count == 0)
        {
            return Error.NotFound("Tasks.NotFound", "There is not tasks"); 
        }
        
        return listOfTasks;
        
    }
}