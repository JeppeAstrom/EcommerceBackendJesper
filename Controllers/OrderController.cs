using EcommerceBackend.Models.Schemas;
using examensarbete_backend.Contexts;
using examensarbete_backend.Models.Dtos.Product;
using examensarbete_backend.Models.Entities;
using Manero_Backend.Helpers.JWT;
using Manero_Backend.Models.Dtos.Order;
using Manero_Backend.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                var order = new OrderEntity
                {
                    AppUserId = userId,
                    PaymentDetailId = schema.PaymentDetailId,
                    AddressId = schema.AddressId,
                    TotalPrice = schema.TotalPrice,
                    OrderProducts = schema.OrderProducts.Select(op => new OrderProductEntity
                    {
                        ProductId = op.ProductId,
                        Size = op.Size
                    }).ToList(),
                    Created = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            };

                _context.Add(order);
                await _context.SaveChangesAsync();
                return Ok(order.Id);
            }
            catch (Exception e) //Ilogger
            {
                return StatusCode(500, e);
            }
        }
     

        [HttpGet("getOrderHistory")]
        [Authorize]
        public async Task<ActionResult<List<OrderDto>>> GetOrders()
        {
            try
            {
            var userId = JwtToken.GetIdFromClaim(HttpContext);

                var orders = await _context.Orders
                                         .Where(o => o.AppUserId == userId)
                                         .Include(o => o.OrderProducts)
                                         .ThenInclude(op => op.Product).ThenInclude(p => p.Images)
                                         .ToListAsync();

                if (orders == null || orders.Count == 0)
                {
                    return NotFound("No orders found for the specified user.");
                }

            return Ok(orders);
            }
            catch (Exception e) //Ilogger
            {
                return StatusCode(500, e);
            }
        }

    }
}
