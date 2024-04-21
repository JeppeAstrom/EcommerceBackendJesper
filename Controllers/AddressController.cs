using EcommerceBackend.Models.Entities;
using EcommerceBackend.Models.Schemas;
using examensarbete_backend.Contexts;
using examensarbete_backend.Models.Dtos.Product;
using Manero_Backend.Helpers.JWT;
using Manero_Backend.Models.Dtos.Address;
using Manero_Backend.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AddressController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync(AddressSchema schema)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("");
            }
            try
            {
                var userId = JwtToken.GetIdFromClaim(HttpContext);

                var AddressEntity = new AddressEntity
                {
                    AppUserId = userId,
                    FirstName = schema.FirstName,
                    LastName = schema.LastName,
                    Street = schema.Street,
                    PostalCode = schema.PostalCode,
                    City = schema.City,
                };
                _context.Add(AddressEntity);
                await _context.SaveChangesAsync();
                return Ok(AddressEntity.Id);

            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        [HttpGet("address")]
        public async Task<ActionResult<AddressDto>> GetAddressId()
        {
            var userId = JwtToken.GetIdFromClaim(HttpContext);
            AddressDto address = await _context.Address.Where(a => a.AppUserId == userId).FirstOrDefaultAsync();
            if (address == null)
            {
                return NotFound();
            }
            return address;
        }
    }
}
