using EcommerceBackend.Models.Entities;
using examensarbete_backend.Models.Entities;
using examensarbete_backend.Models.Schemas;

namespace EcommerceBackend.Models.Schemas;

public class ProductGroupSchema
{
    public List<ProductSchema> Products { get; set; } = new List<ProductSchema>();

    public static implicit operator ProductGroupEntity(ProductGroupSchema productGroup)
    {
        return new ProductGroupEntity
        {
            Products = productGroup.Products?.Select(p => (ProductEntity)p).ToList() ?? new List<ProductEntity>()
        };
    }
}
