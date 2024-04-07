using Manero_Backend.Models.Auth;

namespace examensarbete_backend.Models.Entities;

public class ReviewEntity
{
    public Guid ID { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; }
    public string AppUserId { get; set; } = null!;
    public AppUser AppUser { get; set; }
}
