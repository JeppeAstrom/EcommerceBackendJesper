using examensarbete_backend.Models.Dtos.Reviews;
using Manero_Backend.Models.Auth;
using Manero_Backend.Models.Entities;

namespace examensarbete_backend.Models.Entities;

public class ReviewEntity : BaseEntity
{
    public Guid ID { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = null!;

    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; }

    public string AppUserId { get; set; } = null!;
    public AppUser AppUser { get; set; }
 

    public static implicit operator ReviewDto(ReviewEntity entity)
    {
        return new ReviewDto()
        {
           ID = entity.ID,
           Rating = entity.Rating,
           Comment= entity.Comment,
           ProductId = entity.ProductId,
           Product= entity.Product,
        };
    }
}
