using examensarbete_backend.Models.Dtos;
using examensarbete_backend.Models.Dtos.Category;
using examensarbete_backend.Models.Dtos.Product;
using examensarbete_backend.Models.Dtos.Reviews;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace examensarbete_backend.Models.Entities;

public class ProductEntity
{
    public Guid ID { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public virtual List<ImageEntity> Images { get; set; } = new List<ImageEntity>();
    // Foreign key

 
    public List<CategoryEntity> Categories { get; set; } = new List<CategoryEntity>();
  
    public List<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();


    public static implicit operator ProductDto(ProductEntity productEntity)
{
        return new ProductDto()
        {
            ID = productEntity.ID,
            name = productEntity.Name,
            description = productEntity.Description,
            price = productEntity.Price,
            Images = productEntity.Images.Select(imageEntity => (ImageDto)imageEntity).ToList(),
            Categories = productEntity.Categories.Select(category => new CategoryDto() { ID = category.ID, Name = category.Name }).ToList(),
            Reviews = productEntity.Reviews.Select(r => new ReviewDto
            {
            }).ToList()
        };
    }
}
