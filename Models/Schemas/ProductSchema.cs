using EcommerceBackend.Models.Entities;
using examensarbete_backend.Models.Entities;

namespace examensarbete_backend.Models.Schemas;

public class ProductSchema
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public List<string> ImageUrls { get; set; } = new List<string>();
    public List<string> Sizes { get; set; } = new List<string>();
    public string Color { get; set; }

    public Guid ProductGroupId { get; set; }

    public static implicit operator ProductEntity(ProductSchema product)
    {
        return new ProductEntity
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ProductGroupId = product.ProductGroupId
        };
    }
}
