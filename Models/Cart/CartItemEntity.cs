using examensarbete_backend.Models.Dtos.Product;
using examensarbete_backend.Models.Entities;

namespace EcommerceBackend.Models.Cart;
    public class CartItemEntity
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public virtual CartEntity Cart { get; set; }
        public Guid ProductId { get; set; }
        public string ChosenSize { get; set; }
        public int Quantity { get; set; }
        public virtual decimal Price { get; set; }
     public virtual decimal TotalPrice { get; set; }
}

