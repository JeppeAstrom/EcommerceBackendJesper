using examensarbete_backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace examensarbete_backend.Contexts;

public class DatabaseContext: DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ImageEntity> Images { get; set; }


}

