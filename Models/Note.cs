namespace Basic_dotnet_API.Models;

public class Note
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Foreign key
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    // Foreign key
    public int? FolderId { get; set; }
    public Folder? Folder { get; set; }
}
