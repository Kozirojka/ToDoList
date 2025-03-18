using ErrorOr;
using ToDoTask.Domain;

namespace ToDoTask.Infrastructure;

public interface ITaskRepository
{
    IEnumerable<DoTask> GetAll();
    DoTask GetById(Guid id);
    Success Add(DoTask task);
    bool Put(DoTask task, Guid userId);
    bool Remove(Guid id);
}