using examensarbete_backend.Models.Entities;

namespace Manero_Backend.Models.Entities
{
    public class OrderProductEntity : BaseEntity
    {
        public Guid OrderId { get; set; }
        public OrderEntity Order { get; set; }

        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; }


    }
}
