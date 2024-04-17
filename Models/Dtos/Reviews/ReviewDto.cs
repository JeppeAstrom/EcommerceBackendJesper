using examensarbete_backend.Models.Entities;
using Manero_Backend.Models.Auth;

namespace examensarbete_backend.Models.Dtos.Reviews;

public class ReviewDto
{
    public Guid Id { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public Guid ProductId { get; set; }
    public AppUser AppUser { get; set; }
}
