using EcommerceBackend.Migrations;
using EcommerceBackend.Models.Cart;
using EcommerceBackend.Models.Favourites;
using examensarbete_backend.Contexts;
using examensarbete_backend.Models.Entities;
using examensarbete_backend.Models.Schemas;
using Manero_Backend.Helpers.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public FavouriteController(DatabaseContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ToggleFavourite(Guid productId)
        {
            var userId = JwtToken.GetIdFromClaim(HttpContext);

            var favourites = await _context.Favourites
                                   .Include(f => f.FavouriteProducts)
                                   .ThenInclude(fp => fp.Product)
                                   .FirstOrDefaultAsync(c => c.AppUserId == userId);

            if (favourites == null)
            {
                favourites = new FavouriteEntity { AppUserId = userId, FavouriteProducts = new List<FavouriteProductEntity>() };
                _context.Favourites.Add(favourites);
                await _context.SaveChangesAsync();
            }

            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            var favouriteProduct = favourites.FavouriteProducts.FirstOrDefault(fp => fp.Product.ID == productId);
            if (favouriteProduct != null)
            {
                _context.FavouriteProduct.Remove(favouriteProduct);
                await _context.SaveChangesAsync();
                return Ok("Favorite product removed.");
            }

            else
            {
                favouriteProduct = new FavouriteProductEntity { Product = product };
                favourites.FavouriteProducts.Add(favouriteProduct);
                await _context.SaveChangesAsync();
                return Ok("Product added to favorites.");
            }
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetFavourites()
        {
            var userId = JwtToken.GetIdFromClaim(HttpContext);

            var favourites = await _context.Favourites
                                           .Include(f => f.FavouriteProducts)
                                               .ThenInclude(fp => fp.Product)
                                                   .ThenInclude(p => p.Images) 
                                           .Include(f => f.FavouriteProducts)
                                               .ThenInclude(fp => fp.Product)
                                                   .ThenInclude(p => p.Sizes)  
                                           .Include(f => f.FavouriteProducts)
                                               .ThenInclude(fp => fp.Product)
                                                   .ThenInclude(p => p.Categories) 
                                           .FirstOrDefaultAsync(f => f.AppUserId == userId);

            if (favourites == null || !favourites.FavouriteProducts.Any())
            {
                return NotFound("No favorite products found");
            }

            var productDetails = favourites.FavouriteProducts.Select(fp => new
            {
                ProductId = fp.Product.ID,
                Name = fp.Product.Name,
                Description = fp.Product.Description,
                Price = fp.Product.Price,
                Images = fp.Product.Images.Select(img => img.ImageUrl).ToList(), 
                Sizes = fp.Product.Sizes.Select(s => s.Size).ToList(), 
                Categories = fp.Product.Categories.Select(c => c.Name).ToList() 
            }).ToList();

            return Ok(productDetails);
        }

        [HttpDelete("{productId}")]
        [Authorize]
        public async Task<IActionResult> DeleteFavourite(Guid productId)
        {
            var userId = JwtToken.GetIdFromClaim(HttpContext);

            var favourite = await _context.Favourites
                .Include(f => f.FavouriteProducts)
                    .ThenInclude(fp => fp.Product)
                .FirstOrDefaultAsync(f => f.AppUserId == userId);

            if (favourite == null || !favourite.FavouriteProducts.Any())
            {
                return NotFound("No favorite list or products found.");
            }

            var favouriteProduct = favourite.FavouriteProducts.FirstOrDefault(fp => fp.Product.ID == productId);

            if (favouriteProduct == null)
            {
                return NotFound("Favorite product not found.");
            }

          
            _context.FavouriteProduct.Remove(favouriteProduct);
            await _context.SaveChangesAsync();

            return Ok("Favorite product removed.");
        }

    }
}
