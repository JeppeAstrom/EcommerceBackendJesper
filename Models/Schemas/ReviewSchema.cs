using examensarbete_backend.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace EcommerceBackend.Models.Schemas;

public class ReviewSchema
{
    [RegularExpression("^[0-5]{1}$")]
    public int Rating { get; set; }
    public string Comment { get; set; } = null!;

    public Guid ProductId { get; set; }

    public static implicit operator ReviewEntity(ReviewSchema schema)
    {
        return new ReviewEntity()
        {
            Rating = schema.Rating,
            Comment = schema.Comment,
            ProductId = schema.ProductId
        };
    }
}