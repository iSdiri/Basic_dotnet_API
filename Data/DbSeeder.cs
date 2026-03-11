using Basic_dotnet_API.Models;

namespace Basic_dotnet_API.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.Users.Any()) return;

        var users = new List<User>
        {
            new() { Username = "alice", Email = "alice@example.com" },
            new() { Username = "bob", Email = "bob@example.com" }
        };

        context.Users.AddRange(users);
        context.SaveChanges();

        var tasks = new List<TaskItem>
        {
            new() { Title = "Buy groceries", Description = "Milk, eggs, bread", UserId = 1 },
            new() { Title = "Read a book", Description = "Finish Clean Code", UserId = 1 },
            new() { Title = "Go for a run", Description = "5km minimum", UserId = 2 }
        };

        context.Tasks.AddRange(tasks);
        context.SaveChanges();
    }
}