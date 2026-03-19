using Basic_dotnet_API.DTOs;
using Basic_dotnet_API.Mappers;
using Basic_dotnet_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Basic_dotnet_API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FolderController(IFolderRepository repo) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok((await repo.GetAllAsync()).Select(FolderMapper.ToDto));

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUserId(int userId) =>
        Ok((await repo.GetByUserIdAsync(userId)).Select(FolderMapper.ToDto));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var folder = await repo.GetByIdAsync(id);
        return folder is null ? NotFound() : Ok(FolderMapper.ToDto(folder));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateFolderDto dto)
    {
        var folder = await repo.CreateAsync(FolderMapper.ToModel(dto));
        return CreatedAtAction(nameof(GetById), new { id = folder.Id }, FolderMapper.ToDto(folder));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateFolderDto dto)
    {
        var folder = await repo.GetByIdAsync(id);
        if (folder is null) return NotFound();

        FolderMapper.UpdateModel(folder, dto);
        var updated = await repo.UpdateAsync(id, folder);
        return Ok(FolderMapper.ToDto(updated!));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await repo.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
