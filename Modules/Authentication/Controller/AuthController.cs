using Microsoft.AspNetCore.Mvc;
using DatabaseTutorials.Modules.Authentication.Service;
using DatabaseTutorials.Modules.Authentication.DTOs;
namespace DatabaseTutorials.Modules.Authentication.Controller
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDTO dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var token = _authService.Register(dto);
            if(!token)
            {
                return BadRequest("User Already exists");
            }
            return Ok("Registration Successful please Login");
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _authService.Login(dto);
            if (result == null)
            {
                return BadRequest("Invalid Credentials");
            }
            return Ok(result);
        }
    }
}