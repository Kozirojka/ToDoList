using FluentValidation;
using ToDoTask.Api;
using ToDoTask.Api.Endpoints.Tasks.Validators;
using ToDoTask.Api.Extension;
using ToDoTask.Application.Tasks.Query;
using ToDoTask.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllTasksQueryHandler).Assembly));
builder.Services.AddSingleton<ITaskRepository, TaskRepository>(); 
builder.Services.AddScoped<IValidator<ToDoTask.Domain.DoTask>, TaskValidator>();

builder.RegisterSwagger();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API V1");
            options.RoutePrefix = ""; 
        });
}


app.RegisterAllEndpoints();

app.UseHttpsRedirection();


app.Run();

