using ErrorOr;
using MediatR;
using ToDoTask.Infrastructure;

namespace ToDoTask.Application.Tasks.Query;


public record GetTaskByIdQuery(int Id) : IRequest<ErrorOr<Domain.ToDoTask?>>;

public class GetTaskByIdQueryHandler(TaskRepository repository)
    : IRequestHandler<GetTaskByIdQuery, ErrorOr<Domain.ToDoTask?>>
{
    public async Task<ErrorOr<Domain.ToDoTask?>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var task = repository.GetById(request.Id);

        if (task == null)
        {
            return Error.NotFound($"Task with id {request.Id} not found");
        }

        return task;
    }
}