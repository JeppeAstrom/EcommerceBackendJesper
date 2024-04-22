using EcommerceBackend.Enum;
using examensarbete_backend.Models.Entities;

namespace EcommerceBackend.Models.Schemas;

public class CategorySchema
{
    public string Name { get; set; }
    public Guid ParentCategoryId { get; set; }
    public GenderEnum GenderType { get; set; }
}
