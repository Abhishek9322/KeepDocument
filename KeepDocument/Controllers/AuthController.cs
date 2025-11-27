using KeepDocument.DTOs.AuthDTOs;
using KeepDocument.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KeepDocument.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        public AuthController(IAuthService auth)
        {
            _auth=auth;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequestDto Rdto)
        {
            var registerUser = await _auth.RegisterAsync(Rdto);
            if (registerUser == null)
            {
                return BadRequest();
            }
            return Ok(registerUser);

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestDto Ldto)
        {
            var loginUser = await _auth.LoginAsync(Ldto);
            if (loginUser == null)
            {
                return BadRequest();
            }
            return Ok(loginUser);
        }


    }
}
