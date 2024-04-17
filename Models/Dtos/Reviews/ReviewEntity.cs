using examensarbete_backend.Models.Dtos.Reviews;
using Manero_Backend.Models.Auth;
using Manero_Backend.Models.Entities;

namespace EcommerceBackend.Models.Dtos.Reviews;

public class ReviewEntity : BaseEntity
{
    public Guid Id { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = null!;

    public Guid ProductId { get; set; }

    public string AppUserId { get; set; } = null!;
    public AppUser AppUser { get; set; }


    public static implicit operator ReviewDto(ReviewEntity entity)
    {
        return new ReviewDto()
        {
            Id = entity.Id,
            Rating = entity.Rating,
            Comment = entity.Comment,
            ProductId = entity.ProductId,
            AppUser = entity.AppUser,
        };
    }
}
