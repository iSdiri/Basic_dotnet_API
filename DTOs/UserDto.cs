namespace Basic_dotnet_API.DTOs;

public record CreateUserDto(string Username, string Email);
public record UpdateUserDto(string Username, string Email);
public record ReadUserDto(int Id, string Username, string Email, DateTime CreatedAt);