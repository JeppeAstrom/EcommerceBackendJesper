using examensarbete_backend.Models.Dtos.Product;

namespace EcommerceBackend.Models.Dtos
{
    public class ProductResponseDto
    {
        public int ProductCount { get; set; }
        public List<ProductDto> Products { get; set; }
    }

}
