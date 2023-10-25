using IEntity_TokenGenerator.Models.Dtos;
using IEntity_TokenGenerator.Services;
using Microsoft.AspNetCore.Mvc;

namespace IEntity_TokenGenerator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Register([FromBody] RegistrationDetails registrationDetails)
        {
            var data = await _authService.RegisterAsync(registrationDetails);
            return Ok(data);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDetails loginDetails)
        {
            var data = await _authService.LoginAsync(loginDetails);
            return Ok(data);    
        }
    }
}
