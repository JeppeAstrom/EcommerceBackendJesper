using EcommerceBackend.Models.Cart;
using examensarbete_backend.Contexts;
using Manero_Backend.Helpers.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpPost("AddToCart")]
        [Authorize]
        public async Task<IActionResult> AddToCart(CartItemSchema schema)
        {
            var userId = JwtToken.GetIdFromClaim(HttpContext);
            var cart = _context.Carts.FirstOrDefault(c => c.AppUserId == userId);

            if (cart == null)
            {
                cart = new CartEntity { AppUserId = userId };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            CartItemEntity cartItem;
            var existingCartItem = _context.CartItems
                .FirstOrDefault(ci => ci.CartId == cart.Id && ci.ProductId == schema.ProductId && ci.ChosenSize == schema.ChosenSize);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += 1;
                cartItem = existingCartItem; 
            }
            else
            {
                cartItem = new CartItemEntity
                {
                    CartId = cart.Id,
                    ProductId = schema.ProductId,
                    ChosenSize = schema.ChosenSize,
                    Quantity = 1,
                    ImageUrl = schema.ImageUrl,
                    Name = schema.Name,
                    Description = schema.Description,
                    Price = schema.Price,
                };

                _context.CartItems.Add(cartItem);
            }

            await _context.SaveChangesAsync();

            return Ok(cartItem.Id);
        }


        [HttpDelete("DecreaseItem")]
        [Authorize]
        public async Task<IActionResult> DecreaseFromCart(Guid cartItemId)
        {
            var userId = JwtToken.GetIdFromClaim(HttpContext);

            var cartItem = await _context.CartItems
                                    .Include(ci => ci.Cart)
                                    .FirstOrDefaultAsync(ci => ci.Id == cartItemId && ci.Cart.AppUserId == userId);

            if (cartItem == null)
            {
                return NotFound();
            }

            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity -= 1;
            }
            else
            {
                _context.CartItems.Remove(cartItem);
            }

            await _context.SaveChangesAsync();

            return Ok(cartItem); 
        }

        [HttpDelete("DeleteFromCart")]
        [Authorize]
        public async Task<IActionResult> RemoveFromCart(Guid cartItemId)
        {
            var userId = JwtToken.GetIdFromClaim(HttpContext);

            var cartItem = await _context.CartItems
                                .Include(ci => ci.Cart)
                                .FirstOrDefaultAsync(ci => ci.Id == cartItemId && ci.Cart.AppUserId == userId);
            if (cartItem == null)
            {
                return NotFound();
            }

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();

            return Ok(cartItem);

        }
        [HttpGet]
        public async Task<ActionResult<CartDto>> GetCart()
        {
            var userId = JwtToken.GetIdFromClaim(HttpContext);

            var cart = await _context.Carts
                                     .Include(c => c.Items)
                                     .FirstOrDefaultAsync(c => c.AppUserId == userId);

            if (cart == null)
            {
                return NotFound("Cart not found");
            }

            var totalPrice = cart.Items.Sum(item => item.Quantity * item.Price);

            var cartItemsDto = cart.Items.Select(item => new CartItemEntity
            {
                Id = item.Id,
                CartId = item.CartId,
                Name = item.Name,
                Description = item.Description,
                ImageUrl = item.ImageUrl,
                ProductId = item.ProductId,
                ChosenSize = item.ChosenSize,
                Quantity = item.Quantity,
                Price = item.Price,
                TotalPrice = item.Quantity * item.Price
            }).ToList();

            var cartDto = new CartDto
            {
                Items = cartItemsDto,
                TotalPrice = totalPrice
            };

            return Ok(cartDto);
        }


    }
}
