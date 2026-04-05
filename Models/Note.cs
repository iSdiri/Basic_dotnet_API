namespace Basic_dotnet_API.Models;

public class Note
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Foreign key vers AppUser
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;

    // Foreign key vers Folder (optionnel)
    public int? FolderId { get; set; }
    public Folder? Folder { get; set; }
}
