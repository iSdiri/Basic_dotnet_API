namespace Basic_dotnet_API.Models;

public class Folder
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Foreign key vers AppUser
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;

    public ICollection<Note> Notes { get; set; } = new List<Note>();
}
