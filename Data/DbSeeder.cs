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

        var folders = new List<Folder>
        {
            new() { Name = "Tasks", UserId = 1 },
            new() { Name = "Sport", UserId = 1 },
            new() { Name = "Work", UserId = 1 }
        };

        context.Folders.AddRange(folders);
        context.SaveChanges();

        var notes = new List<Note>
        {
            new() { Title = "Shopping list", Content = "Milk, eggs, bread", UserId = 1, FolderId = 1 },
            new() { Title = "Book notes", Content = "Finish Clean Code chapter 3", UserId = 1, FolderId = 3 },
            new() { Title = "Workout", Content = "Run 5km minimum", UserId = 1, FolderId = 2 }
        };

        context.Notes.AddRange(notes);
        context.SaveChanges();
    }
}
