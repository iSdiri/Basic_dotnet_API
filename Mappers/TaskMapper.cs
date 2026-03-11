using Basic_dotnet_API.DTOs;
using Basic_dotnet_API.Models;

namespace Basic_dotnet_API.Mappers;

public static class TaskMapper
{
    public static ReadTaskDto ToDto(TaskItem task) =>
        new(task.Id, task.Title, task.Description, task.IsCompleted, task.CreatedAt, task.UserId);

    public static TaskItem ToModel(CreateTaskDto dto) =>
        new() { Title = dto.Title, Description = dto.Description, UserId = dto.UserId };

    public static void UpdateModel(TaskItem task, UpdateTaskDto dto)
    {
        task.Title = dto.Title;
        task.Description = dto.Description;
        task.IsCompleted = dto.IsCompleted;
    }
}