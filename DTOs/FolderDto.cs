namespace Basic_dotnet_API.DTOs;

public record CreateFolderDto(string Name, int UserId);
public record UpdateFolderDto(string Name);
public record ReadFolderDto(int Id, string Name, DateTime CreatedAt, int UserId);
