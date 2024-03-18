using examensarbete_backend.Models.Dtos.Category;

namespace examensarbete_backend.Models.Entities;

public class CategoryEntity
{
    public Guid ID { get; set; } 
    public string Name { get; set; } 
    public List<ProductEntity> Products { get; set; }

    public static implicit operator CategoryDto(CategoryEntity category)
    {
        return new CategoryDto
        {
            ID = category.ID,
            Name = category.Name,
        };
    }

}

