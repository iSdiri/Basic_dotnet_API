namespace Basic_dotnet_API.DTOs;

public record CreateTaskDto(string Title, string Description, int UserId);
public record UpdateTaskDto(string Title, string Description, bool IsCompleted);
public record ReadTaskDto(int Id, string Title, string Description, bool IsCompleted, DateTime CreatedAt, int UserId);