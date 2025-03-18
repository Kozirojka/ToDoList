using ErrorOr;
using ToDoTask.Domain;

namespace ToDoTask.Infrastructure;

// TaskRepository that will implement job with database. 
public class TaskRepository : ITaskRepository
{
    private readonly List<DoTask> _tasks = new List<DoTask>();
    
    public IEnumerable<DoTask> GetAll() => _tasks;

    public DoTask GetById(Guid id) => _tasks.FirstOrDefault(t => t.Id == id);
    
    public Success Add(DoTask task)
    {
        //implement automatically increment of ID 
        task.Id = Guid.NewGuid();
        
        _tasks.Add(task);
        return new Success();
    }

    public bool Put(DoTask task, Guid id)
    {
        var existingTask = _tasks.FirstOrDefault(t => t.Id == id);

        if (existingTask != null)
        {
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;

            return true;
        }

        return false;
    }
    
    public bool Remove(Guid id)
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