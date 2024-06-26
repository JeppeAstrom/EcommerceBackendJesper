﻿using EcommerceBackend.Models.Entities;
using examensarbete_backend.Contexts;
using examensarbete_backend.Models.Dtos.Product;
using examensarbete_backend.Models.Entities;
using examensarbete_backend.Models.Schemas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerceBackend.Models.Schemas;
using EcommerceBackend.Models.Dtos.Product;
using examensarbete_backend.Models.Dtos.Category;
using EcommerceBackend.Enum;
using EcommerceBackend.Models.Dtos;

namespace examensarbete_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public ProductsController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ProductResponseDto>> GetProducts(int page = 1, int pageSize = 12)
        {
            int skipAmount = (page - 1) * pageSize;

            List<ProductDto> productEntity = await _context.Products
                .Include(p => p.Images)
                .Include(p => p.Sizes)
                .Include(p => p.Categories)
                .OrderBy(p => p.Name)
                .Skip(skipAmount)
                .Take(pageSize)
                .Select(p => (ProductDto)p)
                .ToListAsync();

            int productCount = await _context.Products.CountAsync();

            var response = new ProductResponseDto
            {
                ProductCount = productCount,
                Products = productEntity
            };

            return Ok(response);
        }


        [HttpPost]
        public async Task<ActionResult<ProductEntity>> PostProduct(ProductSchema product)
        {
            var categories = await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.ID == product.CategoryId);
            ProductEntity entity = product;
            entity.ChosenSize = product.Sizes[0];
            if (categories is not null)
            {
                entity.Categories.Add(categories);
            }

            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
            foreach (var imageUrl in product.ImageUrls)
            {
                _context.Images.Add(new ImageEntity { Id = Guid.NewGuid(), ImageUrl = imageUrl, Product = entity });
            }

            foreach (var size in product.Sizes)
            {
                _context.Sizes.Add(new SizeEntity { Id = Guid.NewGuid(), Size = size, Product=entity });
            }

            await _context.SaveChangesAsync();
            return Created("", "");
        }

        [HttpPost("productGroup")]
        public async Task<ActionResult> PostProductGroup(ProductGroupDto schema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newProductGroup = new ProductGroupEntity
                {
                    Id = schema.Id
                };

                _context.ProductGroups.Add(newProductGroup);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetProductGroup), new { id = newProductGroup.Id }, newProductGroup);
            }
            catch (Exception ex)
            {
             
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }


        [HttpGet("productGroup/{id}")]
        public async Task<ActionResult<ProductGroupEntity>> GetProductGroup(Guid id)
        {
            var productGroup = await _context.ProductGroups
    .Include(pg => pg.Products)
        .ThenInclude(p => p.Images)
    .Include(pg => pg.Products)
        .ThenInclude(p => p.Sizes)
    .Where(pg => pg.Products.Any(p => p.ID == id))
    .FirstOrDefaultAsync();

            if (productGroup == null)
            {
                return NotFound();
            }
            return productGroup;
        }

        [HttpGet("{categoryName}")]
        public async Task<ActionResult<ProductResponseDto>> GetProductsByCategory(string categoryName, GenderEnum genderType, int page = 1, int pageSize = 12)
        {
            int skipAmount = (page - 1) * pageSize;

            List<ProductDto> productEntity = await _context.Products
                .Include(p => p.Sizes)
                .Include(p => p.Images)
                .Include(p => p.Categories)
                .Where(p => p.Categories.Any(c => c.Name == categoryName && c.GenderType == genderType) || p.ParentCategory == categoryName)
                .Skip(skipAmount)
                .Take(pageSize)
                .Select(p => (ProductDto)p)
                .ToListAsync();

            int productCount = await _context.Products
          .Include(p => p.Categories)
          .CountAsync(p => p.Categories.Any(c => c.Name == categoryName && c.GenderType == genderType) || p.ParentCategory == categoryName);

            var response = new ProductResponseDto
            {
                ProductCount = productCount,
                Products = productEntity
            };

            return response;
        }

        [HttpGet("/Products/ById/{productId}")]
        public async Task<ActionResult<ProductDto>> GetProductById(Guid productId)
        {
            ProductDto productEntity = await _context.Products.Include(p => p.Images).Include(p => p.Sizes).Include(p => p.Categories).Where(p => p.ID == productId).Select(p => (ProductDto)p).FirstOrDefaultAsync();

            return productEntity != null ? productEntity : NotFound();
        }


    }
}