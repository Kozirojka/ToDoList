using ErrorOr;
using MediatR;
using ToDoTask.Infrastructure;

namespace ToDoTask.Application.Tasks.Command;



public record DeleteTaskByIdCommand(int UserDeleteId) : IRequest<ErrorOr<Success>>;

public class DeleteTaskByIdCommandHandler(ITaskRepository taskRepository) : IRequestHandler<DeleteTaskByIdCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DeleteTaskByIdCommand request, CancellationToken cancellationToken)
    {
        var result = taskRepository.Remove(request.UserDeleteId);

        if (result)
        {
            return Result.Success;
        }
        else
        {
            return Error.NotFound("Tasks.NotFount", "A Task can not be deleted.");
        }
    }
}