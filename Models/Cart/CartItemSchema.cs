using examensarbete_backend.Models.Dtos.Product;
using examensarbete_backend.Models.Entities;
using examensarbete_backend.Models.Schemas;

namespace EcommerceBackend.Models.Cart;

public class CartItemSchema
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public virtual decimal Price { get; set; }
    public string ChosenSize { get; set; }

}

