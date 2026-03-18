using Basic_dotnet_API.Data;
using Basic_dotnet_API.Models;
using Basic_dotnet_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Basic_dotnet_API.Repositories;

public class NoteRepository(AppDbContext context) : INoteRepository
{
    public async Task<IEnumerable<Note>> GetAllAsync() =>
        await context.Notes.ToListAsync();

    public async Task<Note?> GetByIdAsync(int id) =>
        await context.Notes.FindAsync(id);

    public async Task<Note> CreateAsync(Note note)
    {
        context.Notes.Add(note);
        await context.SaveChangesAsync();
        return note;
    }

    public async Task<Note?> UpdateAsync(int id, Note updated)
    {
        var note = await context.Notes.FindAsync(id);
        if (note is null) return null;

        note.Title = updated.Title;
        note.Content = updated.Content;
        await context.SaveChangesAsync();
        return note;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var note = await context.Notes.FindAsync(id);
        if (note is null) return false;

        context.Notes.Remove(note);
        await context.SaveChangesAsync();
        return true;
    }
}
