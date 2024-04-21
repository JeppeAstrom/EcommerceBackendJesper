using EcommerceBackend.Models.Dtos.Product;
using EcommerceBackend.Models.Dtos.Reviews;
using EcommerceBackend.Models.Entities;
using EcommerceBackend.Models.Interfaces.Services;
using examensarbete_backend.Contexts;
using examensarbete_backend.Models.Dtos.Product;
using examensarbete_backend.Models.Dtos.Reviews;
using examensarbete_backend.Models.Entities;
using Manero_Backend.Helpers.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewController : ControllerBase
{
 
    private readonly DatabaseContext _context;

    public ReviewController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateAsync(ReviewSchema schema)
    {
        if (!ModelState.IsValid)
            return BadRequest("");

        try
        {   
            var userId = JwtToken.GetIdFromClaim(HttpContext);

            var ReviewEntity = new ReviewEntity
            {
                AppUserId= userId,
                ProductId= schema.ProductId,
                Rating= schema.Rating,
                Comment= schema.Comment,
                
            };
            _context.Add(ReviewEntity);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e) //Ilogger
        {
            return StatusCode(500, e);
        }
    }

    [HttpPost("postReview")]
    public async Task<ActionResult> PostProductGroup(CreateReviewDto schema)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var userId = JwtToken.GetIdFromClaim(HttpContext);

        try
        {
            var review = new ReviewEntity
            {
                Comment = schema.Comment,
                Rating = schema.Rating,
                ProductId =schema.ProductId,
                AppUserId= userId,
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return Ok();
        }
        catch (Exception ex)
        {

            return StatusCode(500, "Internal Server Error: " + ex.Message);
        }
    }


    [HttpGet("review/{id}")]
    public async Task<ActionResult<List<ReviewDto>>> GetReviewsFromProduct(Guid id)
    {
        List<ReviewDto> reviews = await _context.Reviews
                                                  .Where(p => p.ProductId == id).Include(a => a.AppUser)
                                                  .Select(r => (ReviewDto)r)
                                                  .ToListAsync();

        return reviews;

    }


}
