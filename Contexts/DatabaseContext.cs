using examensarbete_backend.Models.Entities;
using Manero_Backend.Models.Auth;
using Microsoft.EntityFrameworkCore;

namespace examensarbete_backend.Contexts;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ImageEntity> Images { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

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
    } 


    }

