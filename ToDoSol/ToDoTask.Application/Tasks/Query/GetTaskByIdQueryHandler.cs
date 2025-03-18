using ErrorOr;
using MediatR;
using ToDoTask.Domain;
using ToDoTask.Infrastructure;

namespace ToDoTask.Application.Tasks.Query;


public record GetTaskByIdQuery(Guid Id) : IRequest<ErrorOr<DoTask?>>;

public class GetTaskByIdQueryHandler(ITaskRepository repository)
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