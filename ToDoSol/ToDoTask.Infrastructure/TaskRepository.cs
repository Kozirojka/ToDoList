using ErrorOr;

namespace ToDoTask.Infrastructure;

public class TaskRepository
{
    private readonly List<Domain.ToDoTask> _tasks = new List<Domain.ToDoTask>();
    
    public IEnumerable<Domain.ToDoTask> GetAll() => _tasks;    
    
    public Domain.ToDoTask GetById(int id) => _tasks.FirstOrDefault(t => t.Id == id);
    
    public Success Add(Domain.ToDoTask task)
    {
        _tasks.Add(task);
        return new Success();
    }

    public bool Put(Domain.ToDoTask task, int id)
    {
        var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);

        if (existingTask != null)
        {
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;

            return true;
        }

        return false;
    }
    
    public bool Remove(int id)
    {
        var existingTask = _tasks.FirstOrDefault(t => t.Id == id);

        if (existingTask != null)
        {
            _tasks.Remove(existingTask);
            return true;
        }

        return false;
    }
}