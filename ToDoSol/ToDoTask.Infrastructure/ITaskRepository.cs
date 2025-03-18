using ErrorOr;

namespace ToDoTask.Infrastructure;

public interface ITaskRepository
{
    IEnumerable<Domain.DoTask> GetAll();
    Domain.DoTask GetById(int id);
    Success Add(Domain.DoTask task);
    bool Put(Domain.DoTask task, int id);
    bool Remove(int id);
}