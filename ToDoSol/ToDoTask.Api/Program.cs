using System.Reflection;
using Microsoft.OpenApi.Models;
using ToDoTask.Api;
using ToDoTask.Application.Tasks.Query;
using ToDoTask.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllTasksQueryHandler).Assembly));
builder.Services.AddSingleton<TaskRepository>(); 


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Product API",
        Version = "v1",
        Description = "API для управління продуктами",
    });
});
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

