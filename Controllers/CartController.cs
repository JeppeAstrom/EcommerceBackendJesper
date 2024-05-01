using EcommerceBackend.Models.Cart;
using examensarbete_backend.Contexts;
using Manero_Backend.Helpers.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CartController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(CartItemSchema schema)
        {
            var userId = JwtToken.GetIdFromClaim(HttpContext);

            var cart =  _context.Carts.FirstOrDefault(c => c.AppUserId == userId);

            if (cart == null)
            {
                cart = new CartEntity { AppUserId = userId };
                _context.Carts.Add(cart);
            }

            var cartItem = new CartItemEntity { CartId = cart.Id, ProductId = schema.ProductId, ChosenSize = schema.ChosenSize};

            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();

            return Ok();

        }
    }
}
