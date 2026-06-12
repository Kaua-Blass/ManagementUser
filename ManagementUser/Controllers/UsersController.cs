using Microsoft.AspNetCore.Mvc;
using ManagementUser.Services;
using ManagementUser.DTOs;

namespace ManagementUser.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(
        [FromBody] UserDto.UserCreateRequest dto)
    {
        try
        {
            var user = await _userService.CreateUser(dto);

            return CreatedAtAction(
                nameof(GetUser),
                new { id = user.Id },
                user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _userService.GetUserById(id);

        return user != null
            ? Ok(user)
            : NotFound();
    }
}