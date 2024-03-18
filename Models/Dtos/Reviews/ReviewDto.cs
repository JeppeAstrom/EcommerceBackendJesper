using examensarbete_backend.Models.Entities;

namespace examensarbete_backend.Models.Dtos.Reviews;

public class ReviewDto
{
    public Guid ID { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; }
}
