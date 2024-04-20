using examensarbete_backend.Models.Dtos;
using examensarbete_backend.Models.Dtos.Product;
using examensarbete_backend.Models.Entities;
using Manero_Backend.Models.Auth;
using Manero_Backend.Models.Dtos.Order;

namespace Manero_Backend.Models.Entities
{
    public class OrderEntity : BaseEntity
    {
        public string AppUserId { get; set; } = null!;
        public AppUser AppUser { get; set; }

        public Guid PaymentDetailId { get; set; }

        public PaymentDetailEntity PaymentDetail { get; set; }

        public Guid AddressId { get; set; }
        public AddressEntity Address { get; set; }
        public Guid? PromoCodeId { get; set; }
        public string? ChosenSize { get; set; }

        public decimal TotalPrice { get; set; }
        public string? Comment { get; set; }

        public bool Cancelled { get; set; }
        public string? CancelledMessage { get; set; }

         
        public virtual List<OrderProductEntity> OrderProducts { get; set; } //M:M

        

        public static implicit operator OrderDto(OrderEntity entity)
        {
            return new OrderDto()
            {
                OrderId = entity.Id,
                TotalPrice = entity.TotalPrice,
                
            };
        }

    }
}
