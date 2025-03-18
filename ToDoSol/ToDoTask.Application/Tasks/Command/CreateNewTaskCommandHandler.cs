using ErrorOr;
using MediatR;
using ToDoTask.Domain;
using ToDoTask.Infrastructure;
namespace ToDoTask.Application.Tasks.Command;

public record CreateNewTaskCommand(DoTask task) : IRequest<ErrorOr<Success>>;


public class CreateNewTaskCommandHandler : IRequestHandler<CreateNewTaskCommand, ErrorOr<Success>>
{
    private readonly ITaskRepository _taskRepository;

    public CreateNewTaskCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<ErrorOr<Success>> Handle(CreateNewTaskCommand request, CancellationToken cancellationToken)
    {
        var result = _taskRepository.Add(request.task);

        if (result is Success)
        {
            return Result.Success; 
        }
        
        return Error.NotFound("Tasks.NotFound", "A Task cannot be created"); 

    }
}