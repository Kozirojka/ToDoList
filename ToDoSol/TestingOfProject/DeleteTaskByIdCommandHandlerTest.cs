using Moq;
using ToDoTask.Application.Tasks.Command;
using ToDoTask.Infrastructure;

namespace TestingOfProject;

public class DeleteTaskByIdCommandHandlerTest
{
    
    [Fact]
    public async Task Handle_ExistingTaskId_ShouldReturnSuccess()
    {
        var mockRepository = new Mock<ITaskRepository>();
        var  taskIdToDelete = Guid.NewGuid();
            
        mockRepository.Setup(repo => repo.Remove(taskIdToDelete))
            .Returns(true);
            
        var handler = new DeleteTaskByIdCommandHandler(mockRepository.Object);
        var command = new DeleteTaskByIdCommand(taskIdToDelete);
            
        var result = await handler.Handle(command, CancellationToken.None);
            
        Assert.True(!result.IsError);
        mockRepository.Verify(repo => repo.Remove(taskIdToDelete), Times.Once);
    }
    
    
    [Fact]
    public async Task Handle_NonExistingTaskId_ShouldReturnError()
    {
        var mockRepository = new Mock<ITaskRepository>();
        var nonExistingTaskId = Guid.NewGuid();
            
        mockRepository.Setup(repo => repo.Remove(nonExistingTaskId))
            .Returns(false);
            
        var handler = new DeleteTaskByIdCommandHandler(mockRepository.Object);
        var command = new DeleteTaskByIdCommand(nonExistingTaskId);
            
        var result = await handler.Handle(command, CancellationToken.None);
            
        Assert.True(result.IsError);
        Assert.Equal("Tasks.NotFount", result.FirstError.Code);
        Assert.Equal("A Task can not be deleted.", result.FirstError.Description);
        mockRepository.Verify(repo => repo.Remove(nonExistingTaskId), Times.Once);
    }
    
}