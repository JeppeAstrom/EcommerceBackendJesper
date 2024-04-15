using EcommerceBackend.Models.Entities;

namespace EcommerceBackend.Models.Dtos.Product;

public class ProductGroupDto
{
    public Guid Id { get; set; }
    public List<Size> Sizes { get; set; } = new List<Size>();
    public List<Color> Colors { get; set; } = new List<Color>();
}
