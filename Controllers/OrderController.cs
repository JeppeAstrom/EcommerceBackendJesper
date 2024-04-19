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
    public class OrderController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public OrderController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAsync(OrderSchema schema)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("");
            }
            try
            {
                var userId = JwtToken.GetIdFromClaim(HttpContext);

                var orderEntity = new OrderEntity
                {
                    AppUserId = userId,
                    PaymentDetailId = schema.PaymentDetailId,
                    AddressId = schema.AddressId,
                    TotalPrice = schema.TotalPrice,
                    Cancelled = false,
                    CancelledMessage = schema.CancelledMessage,
                };
                _context.Add(orderEntity);
                await _context.SaveChangesAsync();
                return Ok(orderEntity.Id);
            }
            catch (Exception e) //Ilogger
            {
                return StatusCode(500, e);
            }
        }
        
    }
}
