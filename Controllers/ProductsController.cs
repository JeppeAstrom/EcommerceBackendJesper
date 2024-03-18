﻿using examensarbete_backend.Contexts;
using examensarbete_backend.Models.Dtos.Product;
using examensarbete_backend.Models.Entities;
using examensarbete_backend.Models.Schemas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {
            List<ProductDto> productEntity = await _context.Products.Include(p => p.Images).Include(p => p.Categories).Select(p => (ProductDto)p).ToListAsync();

            return productEntity;
        }

        [HttpPost]
        public async Task<ActionResult<ProductEntity>> PostProduct(ProductSchema product)
        {
            var categories = await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.ID == product.CategoryId);
            ProductEntity entity = product;
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

            return Created("", "");
        }

        [HttpGet("{categoryName}")]
        public async Task<ActionResult<List<ProductDto>>> GetProductsByCategory(string categoryName)
        {
            List<ProductDto> productEntity = await _context.Products.Include(p => p.Images).Include(p => p.Categories).Where(p => p.Categories.Any(c => c.Name == categoryName)).Select(p => (ProductDto)p).ToListAsync();

            return productEntity;
        }
        [HttpGet("/Products/ById/{productId}")]
        public async Task<ActionResult<ProductDto>> GetProductById(Guid productId)
        {
            ProductDto productEntity = await _context.Products.Include(p => p.Images).Include(p => p.Categories).Where(p => p.ID == productId).Select(p => (ProductDto)p).FirstOrDefaultAsync();

            return productEntity != null ? productEntity : NotFound();
        }
    }
}