using EcommerceBackend.Models.Schemas;
using examensarbete_backend.Contexts;
using Manero_Backend.Helpers.JWT;
using Manero_Backend.Models.Dtos.Address;
using Manero_Backend.Models.Dtos.PaymentDetail;
using Manero_Backend.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                    CardName = schema.CardName,
                    CardNumber = schema.CardNumber,
                    Cvv = schema.Cvv,
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
        [HttpGet("paymentdetail")]
        public async Task<ActionResult<PaymentDetailDto>> GetPaymentDetail()
        {
            var userId = JwtToken.GetIdFromClaim(HttpContext);
            PaymentDetailDto payment = await _context.PaymentDetails.Where(a => a.AppUserId == userId).FirstOrDefaultAsync();
            if (payment == null)
            {
                return NotFound();
            }
            return payment;
        }
    }
}
