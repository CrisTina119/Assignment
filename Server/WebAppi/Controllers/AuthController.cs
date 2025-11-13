using ApiContracts.UserFolder;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts.Interfaces;
using Entities;

namespace WebAppi.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository userRepository;

    public AuthController(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginRequest request)
    {
        var user = await userRepository.GetByUserNameAsync(request.Username);

        if (user == null) return Unauthorized("User not found.");

        if (user.Password != request.Password)
            return Unauthorized("Wrong password.");

        var dto = new UserDto
        {
            Id = user.Id,
            Username = user.Username
        };

        return Ok(dto);
    }
}