using Manero_Backend.Models.Auth;

namespace EcommerceBackend.Models.Cart
{
    public class CartDto
    {
        public virtual List<CartItemEntity> Items { get; set; }
        public virtual decimal TotalPrice { get; set; }
    }
}

