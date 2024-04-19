namespace EcommerceBackend.Models.Schemas;

public class PaymentSchema
{
    public string CardName { get; set; } = null!;
    public string CardNumber { get; set; } = null!;
    public string Cvv { get; set; } = null!;
    public string ExpDate { get; set; } = null!;
}
