namespace EcommerceBackend.Models.Entities;

public class Color
{
    public Guid ColorId { get; set; }
    public string ColorName { get; set; }
    public Guid ProductGroupId { get; set; }
    public ProductGroupEntity ProductGroup { get; set; }
}
