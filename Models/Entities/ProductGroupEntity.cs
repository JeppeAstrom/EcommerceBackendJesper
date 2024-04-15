using examensarbete_backend.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace EcommerceBackend.Models.Entities;

public class ProductGroupEntity
{
    [Key]
    public Guid Id { get; set; }
    public virtual List<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    public List<Size> Sizes { get; set; } = new List<Size>();
    public List<Color> Colors { get; set; } = new List<Color>();
}
