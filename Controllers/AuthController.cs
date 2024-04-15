using EcommerceBackend.Models.Schemas;
using Manero_Backend.Models.Interfaces.Services;
using Manero_Backend.Models.Schemas.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterSchema schema)
        {
            if (!ModelState.IsValid)
                return BadRequest("");

            try
            {
                return await _authService.RegisterAsync(schema);
            }
            catch (Exception e) //Ilogger
            {
                return StatusCode(500, e);
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginSchema schema)
        {
            if (!ModelState.IsValid)
                return BadRequest("");

            try
            {
                return await _authService.LoginAsync(schema);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet("validatetoken")]
        [Authorize]
        public async Task<IActionResult> ValidateToken()
        {
            return NoContent();
        }
    }
}
