namespace EcommerceBackend.Models.Dtos.Reviews;

public class CreateReviewDto
{
    public Guid Id { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public Guid ProductId { get; set; }
}
