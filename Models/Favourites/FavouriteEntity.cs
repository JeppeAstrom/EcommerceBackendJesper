using examensarbete_backend.Models.Entities;
using Manero_Backend.Models.Auth;

namespace EcommerceBackend.Models.Favourites;

public class FavouriteEntity
{
    public Guid Id { get; set; }
    public string AppUserId { get; set; } = null!;
    public AppUser AppUser { get; set; }
    public virtual List<FavouriteProductEntity> FavouriteProducts { get; set; }
}
