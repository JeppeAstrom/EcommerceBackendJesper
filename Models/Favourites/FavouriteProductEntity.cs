using examensarbete_backend.Models.Entities;

namespace EcommerceBackend.Models.Favourites;

public class FavouriteProductEntity
{
    public Guid Id { get; set; }
    public ProductEntity Product { get; set; }
}
