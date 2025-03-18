FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ToDoTask.Api/ToDoTask.Api.csproj", "ToDoTask.Api/"]
COPY ["ToDoTask.Infrastructure/ToDoTask.Infrastructure.csproj", "ToDoTask.Infrastructure/"]
COPY ["ToDoTask.Domain/ToDoTask.Domain.csproj", "ToDoTask.Domain/"]
COPY ["ToDoTask.Application/ToDoTask.Application.csproj", "ToDoTask.Application/"]
RUN dotnet restore "ToDoTask.Api/ToDoTask.Api.csproj"
COPY . .
WORKDIR "/src/ToDoTask.Api"
RUN dotnet build "ToDoTask.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ToDoTask.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoTask.Api.dll"]
