using Microsoft.OpenApi.Models;

namespace ToDoTask.Api;

public static class SwaggerExtention
{
    public static void RegisterSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Product API",
                Version = "v1",
                Description = "API для управління продуктами",
            });
        });
    }
}