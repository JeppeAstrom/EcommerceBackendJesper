﻿using examensarbete_backend.Models.Entities;
using Manero_Backend.Models.Entities;

namespace EcommerceBackend.Models.Schemas;

public class OrderSchema
{
    public Guid PaymentDetailId { get; set; }
    public Guid AddressId { get; set; }
    public Guid? PromoCodeId { get; set; }
    public bool Cancelled { get; set; }
    public decimal TotalPrice { get; set; }
    public string? CancelledMessage { get; set; }
    public virtual List<OrderProductEntity> OrderProducts{ get; set; }

    public static implicit operator OrderEntity(OrderSchema schema)
    {
        return new OrderEntity()
        {
            PaymentDetailId = schema.PaymentDetailId,
            AddressId = schema.AddressId,
            PromoCodeId = schema.PromoCodeId,
            TotalPrice = schema.TotalPrice,
        };
    }
}
