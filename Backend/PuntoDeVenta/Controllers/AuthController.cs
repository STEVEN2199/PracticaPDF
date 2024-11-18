using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PuntoDeVenta.Dtos;
using PuntoDeVenta.Services;

namespace PuntoDeVenta.Controllers
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

        //[AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (!await _authService.RegisterAsync(dto))
                return BadRequest("User already exists.");
            return Ok("User registered successfully.");
        }

        //[AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var tokens = await _authService.LoginAsync(dto);
            if (tokens.AccessToken == null) return Unauthorized("Invalid credentials.");
            return Ok(tokens);
        }

        //[AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenDto dto)
        {
            var newAccessToken = await _authService.RefreshTokenAsync(dto);
            if (newAccessToken == null) return Unauthorized("Invalid refresh token.");
            return Ok(new { AccessToken = newAccessToken });
        }
    }
}
