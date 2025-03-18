using ErrorOr;
using MediatR;
using ToDoTask.Infrastructure;

namespace ToDoTask.Application.Tasks.Command;



public record UpdateTaskCommand(Domain.ToDoTask Task, int Id) : IRequest<ErrorOr<Success>>;

public class UpdateTaskCommandHandler(TaskRepository repository) : IRequestHandler<UpdateTaskCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var result = repository.Put(request.Task, request.Id);
        
        if (result)
        {
            return Result.Success;
        }
        else
        {
            return Error.NotFound("Tasks.NotFount", "A Task can not be updated.");
        }
    }
}