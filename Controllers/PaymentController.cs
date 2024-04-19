using EcommerceBackend.Models.Schemas;
using examensarbete_backend.Contexts;
using Manero_Backend.Helpers.JWT;
using Manero_Backend.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public PaymentController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync(PaymentSchema schema)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("");
            }
            try
            {
                var userId = JwtToken.GetIdFromClaim(HttpContext);

                var paymentDetailEntity = new PaymentDetailEntity
                {
                    AppUserId = userId,
                    Cvv = schema.Cvv,
                    CardName = schema.CardName,
                    ExpDate = schema.ExpDate,
                };
                _context.Add(paymentDetailEntity);
                await _context.SaveChangesAsync();
                return Ok(paymentDetailEntity.Id);

            }
            catch (Exception e) //Ilogger
            {
                return StatusCode(500, e);
            }
        }
    }
}
