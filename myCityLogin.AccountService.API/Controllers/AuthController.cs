using Microsoft.AspNetCore.Mvc;
using myCityLogin.AccountService.API.DTOs;
using myCityLogin.AccountService.API.Interfaces;

namespace myCityLogin.AccountService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var result = await _authService.Register(dto);

            if (result == "User already exists")
            {
                return Conflict(new { message = result });
            }

            return Ok(new { message = result });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.Login(dto);

            if (result == "Invalid credentials")
            {
                return Unauthorized(new { message = result });
            }

            return Ok(new { token = result });
        }
    }
}
