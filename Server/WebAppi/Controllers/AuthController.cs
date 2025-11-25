using ApiContracts.UserFolder;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts.Interfaces;

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

      [HttpPost]
   public async Task<ActionResult<UserDto>> Login([FromBody] LoginRequest request)
             {
            var u = await users!.GetByUserNameAsync(request.UserName!);
            if (u is null)
                return Unauthorized("user not found");
                  if (u.Passsword != request.Password)
        return Unauthorized("Invalid password");

            var dto = new UserDto
            {
                Id = u.Id,
                Username = u.Username!
            };
            return dto;
        }
    }
