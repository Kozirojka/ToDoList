﻿using ErrorOr;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using ToDoTask.Api.Endpoints.Tasks;
using ToDoTask.Application.Tasks.Command;
using ToDoTask.Domain;
using ToDoTask.Infrastructure;

namespace TestingOfProject;

public class CreateNewTaskCommandHandlerTests
{
    [Fact]
    public async Task TesetForSuccesullyCreatedToDoTask()
    {
        var mockRepository = new Mock<ITaskRepository>();
        var task = new DoTask { Id = Guid.NewGuid(), Title = "Test", Description = "Test Description", IsCompleted = false };

        mockRepository.Setup(repo => repo.Add(It.IsAny<DoTask>())).Returns(new Success());

        var handler = new CreateNewTaskCommandHandler(mockRepository.Object);
        var command = new CreateNewTaskCommand(task);
        var cancellationToken = new CancellationToken();

        var result = await handler.Handle(command, cancellationToken);

        Assert.False(result.IsError);
        Assert.IsType<Success>(result.Value);
    }
    
    
}