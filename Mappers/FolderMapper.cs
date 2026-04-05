using Basic_dotnet_API.DTOs;
using Basic_dotnet_API.Models;

namespace Basic_dotnet_API.Mappers;

public static class FolderMapper
{
    public static ReadFolderDto ToDto(Folder folder) =>
        new(folder.Id, folder.Name, folder.CreatedAt, folder.AppUserId);

    public static Folder ToModel(CreateFolderDto dto) =>
        new() { Name = dto.Name, AppUserId = dto.AppUserId };

    public static void UpdateModel(Folder folder, UpdateFolderDto dto)
    {
        folder.Name = dto.Name;
    }
}
