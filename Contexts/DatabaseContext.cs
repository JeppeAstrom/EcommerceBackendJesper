using EcommerceBackend.Models.Cart;
using EcommerceBackend.Models.Dtos.Reviews;
using EcommerceBackend.Models.Entities;
using EcommerceBackend.Models.Schemas;
using examensarbete_backend.Models.Entities;
using Manero_Backend.Models.Auth;
using Manero_Backend.Models.Entities;
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
    public DbSet<SizeEntity> Sizes { get; set; }
    public DbSet<ProductGroupEntity> ProductGroups { get; set; }
    public DbSet<ReviewEntity> Reviews { get; set; }
    public DbSet<AddressEntity> Address { get; set; }
    public DbSet<PaymentDetailEntity> PaymentDetails { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderProductEntity> OrderProducts { get; set; }

    public DbSet<CartEntity> Carts { get; set; }
    public DbSet<CartItemEntity> CartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ProductEntity>().HasKey(p => p.ID);

            modelBuilder.Entity<ProductEntity>()
        .HasOne(p => p.ProductGroup)
        .WithMany()
        .HasForeignKey(p => p.ProductGroupId);

        modelBuilder.Entity<OrderEntity>(entity =>
        {
            entity.HasMany(e => e.OrderProducts)
                  .WithOne(op => op.Order)
                  .HasForeignKey(op => op.OrderId);
        });

        modelBuilder.Entity<SizeEntity>(size =>
        {
            size.HasOne(s => s.Product).WithMany(p => p.Sizes).HasForeignKey(s => s.ProductId);
        });
      
        modelBuilder.Entity<OrderProductSchema>(entity =>
        {
            entity.HasNoKey();
        });

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

