using ErrorOr;
using ToDoTask.Domain;

namespace ToDoTask.Infrastructure;

// TaskRepository that will implement job with database. 
public class TaskRepository : ITaskRepository
{
    private readonly List<DoTask> _tasks = new List<DoTask>();
    
    public IEnumerable<DoTask> GetAll() => _tasks;    
    
    public DoTask GetById(int id) => _tasks.FirstOrDefault(t => t.Id == id);
    
    public Success Add(DoTask task)
    {
        //implement automatically increment of ID 
        task.Id = _tasks.Count + 1;
        
        _tasks.Add(task);
        return new Success();
    }

    public bool Put(DoTask task, int id)
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