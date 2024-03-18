using examensarbete_backend.Models.Dtos;

namespace examensarbete_backend.Models.Entities;

public class ImageEntity
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; }
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; }

    public static implicit operator ImageDto(ImageEntity entity)
    {
        return new ImageDto
        {
            Id = entity.Id,
            ImageUrl = entity.ImageUrl,
        };
    }
}
