using EcommerceBackend.Models.Dtos;
using examensarbete_backend.Models.Dtos;
using examensarbete_backend.Models.Entities;

namespace EcommerceBackend.Models.Entities;

public class SizeEntity
{
    public Guid Id { get; set; } 
    public string Size { get; set; }
    public Guid ProductId { get; set; }
    public virtual ProductEntity Product { get; set; } = null!;

    public static implicit operator SizeDto(SizeEntity entity)
    {
        return new SizeDto
        {
            Id = entity.Id,
            Size = entity.Size
        };
    }
}
