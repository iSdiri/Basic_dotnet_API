using Basic_dotnet_API.Models;

namespace Basic_dotnet_API.Repositories.Interfaces;

public interface INoteRepository
{
    Task<IEnumerable<Note>> GetAllAsync();
    Task<Note?> GetByIdAsync(int id);
    Task<Note> CreateAsync(Note note);
    Task<Note?> UpdateAsync(int id, Note note);
    Task<bool> DeleteAsync(int id);
}
