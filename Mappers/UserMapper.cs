using Basic_dotnet_API.DTOs;
using Basic_dotnet_API.Models;

namespace Basic_dotnet_API.Mappers;

public static class UserMapper
{
    public static ReadUserDto ToDto(User user) =>
        new(user.Id, user.Username, user.Email, user.CreatedAt);

    public static User ToModel(CreateUserDto dto) =>
        new() { Username = dto.Username, Email = dto.Email };

    public static void UpdateModel(User user, UpdateUserDto dto)
    {
        user.Username = dto.Username;
        user.Email = dto.Email;
    }
}