using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sem2FirstProject.DTOs.Request;
using Sem2FirstProject.DTOs.Response;
using Sem2FirstProject.Services.Interfaces;

namespace Sem2FirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterUser(RegisterUserDto userDto)
        {
            var response = await authService.RegisterUserAsync(userDto);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var loginResponse = await authService.Login(loginDto);
            if (loginResponse.Success)
            {
                return Ok(loginResponse);
            }
            return Unauthorized(loginResponse);
        }



    }
}
