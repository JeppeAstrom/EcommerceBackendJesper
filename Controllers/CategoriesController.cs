using EcommerceBackend.Models.Dtos.Category;
using EcommerceBackend.Models.Schemas;
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
        public async Task<IActionResult> CreateCategory([FromBody] CategorySchema schema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = new CategoryEntity
            {
                Name = schema.Name,
                ParentCategoryId = schema.ParentCategoryId,
                GenderType = schema.GenderType,
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryEntity>>> GetCategories()
        {
            return await _context.Categories.Where(c => c.ParentCategoryId == Guid.Empty).ToListAsync();
        }

        [HttpGet("childCategoriesFromName")]
        public async Task<ActionResult<CategoryDto>> GetCategoriesFromName(string name)
        {
            var mainCategory = await _context.Categories.Where(c => c.ParentCategoryId == Guid.Empty && c.Name == name).FirstOrDefaultAsync();
            
            if(mainCategory is null)
            {
                return BadRequest("Could not find category");
            }

            var subCategories = await _context.Categories.Where(c => c.ParentCategoryId == mainCategory.ID).ToListAsync();

            var newCategory = new CategoryDto()
            {
                ID = mainCategory.ID,
                Name = mainCategory.Name,
                ParentCategory = null,
                ChildCategories = subCategories.Select(c => new ChildCategoryDto() { Id = c.ID, Name = c.Name }).ToList(),
            };

            return newCategory;
        }

        [HttpGet("childCategories")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategoriesFromName()
        {
            var mainCategories = await _context.Categories.Where(c => c.ParentCategoryId == Guid.Empty).ToListAsync();

             var List = new List<CategoryDto>();

            foreach (var category in mainCategories)
            {
                var subCategories = await _context.Categories.Where(c => c.ParentCategoryId == category.ID).ToListAsync();
                var newCategory = new CategoryDto()
                {
                    ID = category.ID,
                    Name = category.Name,
                    ParentCategory = null,

                };
                if (subCategories.Count > 0)
                {
                    foreach (var subCategory in subCategories)
                    {
                        var subCategoryDto = new ChildCategoryDto()
                        {
                            Id = subCategory.ID,
                            Name = subCategory.Name
                        };
                        newCategory.ChildCategories.Add(subCategoryDto);

                    }
                }
                List.Add(newCategory);
            }
            return List;
        }
    }
}