using Basic_dotnet_API.Data;
using Basic_dotnet_API.Models;
using Basic_dotnet_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Basic_dotnet_API.Repositories;

public class FolderRepository(AppDbContext context) : IFolderRepository
{
    public async Task<IEnumerable<Folder>> GetAllAsync() =>
        await context.Folders.ToListAsync();

    public async Task<IEnumerable<Folder>> GetByUserIdAsync(int userId) =>
        await context.Folders.Where(f => f.UserId == userId).ToListAsync();

    public async Task<Folder?> GetByIdAsync(int id) =>
        await context.Folders.FindAsync(id);

    public async Task<Folder> CreateAsync(Folder folder)
    {
        context.Folders.Add(folder);
        await context.SaveChangesAsync();
        return folder;
    }

    public async Task<Folder?> UpdateAsync(int id, Folder updated)
    {
        var folder = await context.Folders.FindAsync(id);
        if (folder is null) return null;

        folder.Name = updated.Name;
        await context.SaveChangesAsync();
        return folder;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var folder = await context.Folders.FindAsync(id);
        if (folder is null) return false;

        context.Folders.Remove(folder);
        await context.SaveChangesAsync();
        return true;
    }
}
