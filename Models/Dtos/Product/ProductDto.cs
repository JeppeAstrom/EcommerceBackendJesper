using examensarbete_backend.Models.Dtos.Category;
using examensarbete_backend.Models.Dtos.Reviews;
using examensarbete_backend.Models.Entities;

namespace examensarbete_backend.Models.Dtos.Product;

public class ProductDto
{
    public Guid ID { get; set; }
    public string name { get; set; } = null!;
    public string description { get; set; } = null!;

    public List<ImageDto> Images { get; set; } = new List<ImageDto>();
    public decimal price { get; set; }
    public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    public List<ReviewDto> Reviews { get; set; } = new List<ReviewDto>();
}
