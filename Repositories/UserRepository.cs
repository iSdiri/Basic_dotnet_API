using Basic_dotnet_API.Data;
using Basic_dotnet_API.Models;
using Basic_dotnet_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Basic_dotnet_API.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<IEnumerable<User>> GetAllAsync() =>
        await context.Users.ToListAsync();

    public async Task<User?> GetByIdAsync(int id) =>
        await context.Users.FindAsync(id);

    public async Task<User> CreateAsync(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> UpdateAsync(int id, User updated)
    {
        var user = await context.Users.FindAsync(id);
        if (user is null) return null;

        user.Username = updated.Username;
        user.Email = updated.Email;
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user is null) return false;

        context.Users.Remove(user);
        await context.SaveChangesAsync();
        return true;
    }
}