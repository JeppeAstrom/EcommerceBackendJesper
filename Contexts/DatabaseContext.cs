using EcommerceBackend.Models.Entities;
using examensarbete_backend.Models.Entities;
using Manero_Backend.Models.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace examensarbete_backend.Contexts;

public class DatabaseContext : IdentityDbContext<AppUser>
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ImageEntity> Images { get; set; }
    public DbSet<ProductGroupEntity> ProductGroups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Size>().HasKey(s => s.SizeId);
        modelBuilder.Entity<Color>().HasKey(c => c.ColorId);

        modelBuilder.Entity<ProductGroupEntity>()
            .HasMany(p => p.Sizes)
            .WithOne(s => s.ProductGroup)
            .HasForeignKey(s => s.ProductGroupId);

        modelBuilder.Entity<ProductGroupEntity>()
            .HasMany(p => p.Colors)
            .WithOne(c => c.ProductGroup)
            .HasForeignKey(c => c.ProductGroupId);

        modelBuilder.Entity<AppUser>(appUser =>
        {
            appUser.HasMany(au => au.Addresses)
            .WithOne(a => a.AppUser)
            .HasForeignKey(a => a.AppUserId)
            .OnDelete(DeleteBehavior.NoAction);

         

            appUser.HasMany(au => au.PaymentDetails)
            .WithOne(pd => pd.AppUser)
            .HasForeignKey(pd => pd.AppUserId)
            .OnDelete(DeleteBehavior.NoAction);


            appUser.HasMany(au => au.Reviews)
            .WithOne(r => r.AppUser)
            .HasForeignKey(r => r.AppUserId)
            .OnDelete(DeleteBehavior.NoAction);

        });
        modelBuilder.Entity<ProductGroupEntity>(productGroup =>
        {
            productGroup.HasMany(p => p.Products)
                .WithOne(p => p.ProductGroup)
                .HasForeignKey(p => p.ProductGroupId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    } 
    }

