using Moq;
using ToDoTask.Application.Tasks.Command;
using ToDoTask.Domain;
using ToDoTask.Infrastructure;

namespace TestingOfProject;

public class UpdateTaskByIdCommandHandlerTest
{
    [Fact]
    public async Task Handle_ExistingTask_ShouldReturnSuccess()
    {
        var mockRepository = new Mock<ITaskRepository>();
        var taskId = Guid.NewGuid();
            
        var taskToUpdate = new DoTask
        {
            Id = taskId,
            Title = "Updated Title",
            Description = "Updated Description",
            IsCompleted = true,
            DueDate = DateTime.Now.AddDays(1)
        };
            
        mockRepository.Setup(repo => repo.Put(taskToUpdate, taskId))
            .Returns(true);
            
        var handler = new UpdateTaskCommandHandler(mockRepository.Object);
        var command = new UpdateTaskCommand(taskToUpdate, taskId);
            
        var result = await handler.Handle(command, CancellationToken.None);
            
        Assert.True(!result.IsError);
        mockRepository.Verify(repo => repo.Put(taskToUpdate, taskId), Times.Once);
    }
}