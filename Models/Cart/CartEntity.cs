using Manero_Backend.Models.Auth;

namespace EcommerceBackend.Models.Cart;

public class CartEntity
{
    public Guid Id { get; set; }
    public string AppUserId { get; set; } = null!;
    public AppUser AppUser { get; set; }
    public virtual List<CartItemEntity> Items {get; set;}
}
