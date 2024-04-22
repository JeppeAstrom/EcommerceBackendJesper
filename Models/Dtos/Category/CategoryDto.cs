using EcommerceBackend.Models.Dtos.Category;
using examensarbete_backend.Models.Entities;

namespace examensarbete_backend.Models.Dtos.Category;

public class CategoryDto
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public ParentCategoryDto? ParentCategory { get; set; }
    public List<ChildCategoryDto>? ChildCategories { get; set; } = new List<ChildCategoryDto>();
}
