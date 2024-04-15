using EcommerceBackend.Models.Entities;
using examensarbete_backend.Models.Entities;
using examensarbete_backend.Models.Schemas;

namespace EcommerceBackend.Models.Schemas;

public class ProductGroupSchema
{
    public List<Size> Sizes { get; set; } = new List<Size>();
    public List<Color> Colors { get; set; } = new List<Color>();
    public List<ProductSchema> Products { get; set; } = new List<ProductSchema>();

    public static implicit operator ProductGroupEntity(ProductGroupSchema productGroup)
    {
        return new ProductGroupEntity
        {
            Sizes = productGroup.Sizes ?? new List<Size>(),
            Colors = productGroup.Colors ?? new List<Color>(),
            Products = productGroup.Products?.Select(p => (ProductEntity)p).ToList() ?? new List<ProductEntity>()
        };
    }
}
