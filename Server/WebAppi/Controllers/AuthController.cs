using ApiContracts;
using ApiContracts.UserFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryContracts.Interfaces;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserRepository? users;
        public AuthController(IUserRepository users)
        {
            this.users = users;
        }

        [HttpPost]
   public async Task<ActionResult<UserDto>> Login([FromBody] LoginRequest request)
             {
            var u = await users!.GetByUserNameAsync(request.UserName!);
            if (u is null)
                return Unauthorized("user not found");
                  if (u.Password != request.Password)
        return Unauthorized("Invalid password");

            var dto = new UserDto
            {
                Id = u.Id,
                Username = u.Username!
            };
            return dto;
        }
    }
}
