namespace EcommerceBackend.Models.Entities;

public class Size
{
    public Guid SizeId { get; set; } 
    public string SizeName { get; set; }
    public Guid ProductGroupId { get; set; }
    public ProductGroupEntity ProductGroup { get; set; }
}
