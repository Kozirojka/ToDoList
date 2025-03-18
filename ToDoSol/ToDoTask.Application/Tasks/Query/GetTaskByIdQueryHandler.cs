using ErrorOr;
using MediatR;
using ToDoTask.Domain;
using ToDoTask.Infrastructure;

namespace ToDoTask.Application.Tasks.Query;


public record GetTaskByIdQuery(int Id) : IRequest<ErrorOr<DoTask?>>;

public class GetTaskByIdQueryHandler(TaskRepository repository)
    : IRequestHandler<GetTaskByIdQuery, ErrorOr<DoTask?>>
{
    public async Task<ErrorOr<DoTask?>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var task = repository.GetById(request.Id);

        if (task == null)
        {
            return Error.NotFound($"Task with id {request.Id} not found");
        }

        return task;
    }
}