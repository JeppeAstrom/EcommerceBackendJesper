using examensarbete_backend.Contexts;
using Manero_Backend.Helpers.JWT;
using Manero_Backend.Models.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly DatabaseContext _context;

    public ProfileController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<UserProfileDto>> GetProfile()
    {
        var userId = JwtToken.GetIdFromClaim(HttpContext);

        if(userId == null)
        {
            return NotFound();
        }

        var userProfile = await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();


        if (userProfile == null)
        {
            return BadRequest("");
        }

        var profileDto = new UserProfileDto
        {
            FirstName = userProfile.FirstName,
            LastName = userProfile.LastName,
            Email = userProfile.Email,
            ImageUrl = userProfile.ImageUrl,
            PhoneNumber = userProfile.PhoneNumber,
            Location = userProfile.Location,
        };

        return profileDto;
    }
}
