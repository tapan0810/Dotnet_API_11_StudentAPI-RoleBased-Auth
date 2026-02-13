using Dotnet_API_11_.Dtos.UserDto;
using Dotnet_API_11_.Services.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_API_11_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {

        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(UserDto user)
        {
            var result = await authService.Register(user);

            if (result is null)
                return BadRequest("User already exists!");

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto user)
        {
            var result = await authService.login(user);

            if (user is null)
                return BadRequest("Invalid User😢😢");

            return Ok(result);
        }
    }
}
