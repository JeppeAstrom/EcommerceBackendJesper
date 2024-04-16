using examensarbete_backend.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace EcommerceBackend.Models.Entities;

public class ProductGroupEntity
{
    [Key]
    public Guid Id { get; set; }
    public virtual List<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}
