using Basic_dotnet_API.Models;

namespace Basic_dotnet_API.Repositories.Interfaces;

public interface IFolderRepository
{
    Task<IEnumerable<Folder>> GetAllAsync();
    Task<IEnumerable<Folder>> GetByUserIdAsync(int userId);
    Task<Folder?> GetByIdAsync(int id);
    Task<Folder> CreateAsync(Folder folder);
    Task<Folder?> UpdateAsync(int id, Folder folder);
    Task<bool> DeleteAsync(int id);
}
