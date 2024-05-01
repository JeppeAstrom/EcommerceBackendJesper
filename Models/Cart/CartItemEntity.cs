using examensarbete_backend.Models.Dtos.Product;
using examensarbete_backend.Models.Entities;

namespace EcommerceBackend.Models.Cart;
    public class CartItemEntity
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public virtual CartEntity Cart { get; set; }
        public Guid ProductId { get; set; }
        public string ChosenSize { get; set; }
}

