using examensarbete_backend.Contexts;
using examensarbete_backend.Models.Dtos.Category;
using examensarbete_backend.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace examensarbete_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public CategoriesController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = new CategoryEntity
            {
                Name = categoryDto.Name
            };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            // Map the category entity to a DTO
            var categoryDtoResult = new CategoryDto
            {
                ID = category.ID,
                Name = category.Name
                // Include other properties as needed
            };

            // Return the DTO in the response
            return CreatedAtAction(nameof(CreateCategory), new { id = category.ID }, categoryDtoResult);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryEntity>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }



    }
}