namespace Basic_dotnet_API.Models;

public class Folder
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Foreign key
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    // Navigation property
    public ICollection<Note> Notes { get; set; } = new List<Note>();
}
