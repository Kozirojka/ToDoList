namespace ToDoTask.Infrastructure;

public class TaskRepository
{
    private readonly List<Domain.ToDoTask> _tasks = new List<Domain.ToDoTask>();
    
    public IEnumerable<Domain.ToDoTask> GetAll() => _tasks;    
    
    public Domain.ToDoTask GetById(int id) => _tasks.FirstOrDefault(t => t.Id == id);
    
    public void Add(Domain.ToDoTask task) => _tasks.Add(task);

    public void Put(Domain.ToDoTask task)
    {
        var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);

        if (existingTask != null)
        {
            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;
        }
        
    }
    
    public void Remove(Domain.ToDoTask task) => _tasks.Remove(task);
    
}