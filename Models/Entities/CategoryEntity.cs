using EcommerceBackend.Enum;
using examensarbete_backend.Models.Dtos.Category;
using System.Runtime.CompilerServices;

namespace examensarbete_backend.Models.Entities;

public class CategoryEntity
{
    public Guid ID { get; set; } 
    public string Name { get; set; } 
    public GenderEnum GenderType { get; set; }
    public string? ImageUrl { get; set; }
    public Guid ParentCategoryId { get; set; }
    public virtual List<CategoryEntity> ChildCategories { get; set; } = new List<CategoryEntity>();
    public virtual List<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}

