namespace EcommerceBackend.Models.Schemas;

public class AddressSchema
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
}
