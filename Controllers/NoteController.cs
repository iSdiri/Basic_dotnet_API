using Basic_dotnet_API.DTOs;
using Basic_dotnet_API.Mappers;
using Basic_dotnet_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Basic_dotnet_API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class NoteController(INoteRepository repo) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok((await repo.GetAllAsync()).Select(NoteMapper.ToDto));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var note = await repo.GetByIdAsync(id);
        return note is null ? NotFound() : Ok(NoteMapper.ToDto(note));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateNoteDto dto)
    {
        var note = await repo.CreateAsync(NoteMapper.ToModel(dto));
        return CreatedAtAction(nameof(GetById), new { id = note.Id }, NoteMapper.ToDto(note));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateNoteDto dto)
    {
        var note = await repo.GetByIdAsync(id);
        if (note is null) return NotFound();

        NoteMapper.UpdateModel(note, dto);
        var updated = await repo.UpdateAsync(id, note);
        return Ok(NoteMapper.ToDto(updated!));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await repo.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
