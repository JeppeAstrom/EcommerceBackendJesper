namespace EcommerceBackend.Models.Schemas;

public class OrderSchema
{
    public Guid PaymentDetailId { get; set; }
    public Guid AddressId { get; set; }
    public decimal TotalPrice { get; set; }
    public bool Cancelled { get; set; }
    public string? CancelledMessage { get; set; }
}
