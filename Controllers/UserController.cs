using Basic_dotnet_API.DTOs;
using Basic_dotnet_API.Mappers;
using Basic_dotnet_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Basic_dotnet_API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController(IUserRepository repo) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok((await repo.GetAllAsync()).Select(UserMapper.ToDto));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await repo.GetByIdAsync(id);
        return user is null ? NotFound() : Ok(UserMapper.ToDto(user));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserDto dto)
    {
        var user = await repo.CreateAsync(UserMapper.ToModel(dto));
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, UserMapper.ToDto(user));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateUserDto dto)
    {
        var user = await repo.GetByIdAsync(id);
        if (user is null) return NotFound();

        UserMapper.UpdateModel(user, dto);
        var updated = await repo.UpdateAsync(id, user);
        return Ok(UserMapper.ToDto(updated!));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await repo.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
