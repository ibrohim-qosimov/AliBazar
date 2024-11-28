using AliBazar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AliBazar.Infrastructure.Persistance;

public class AliBazarDbContext : DbContext
{
    public AliBazarDbContext(DbContextOptions<AliBazarDbContext> options)
        : base(options)
    {
        Database.Migrate();
    }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrdersItem { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<ProductColor> ProductColors { get; set; }
    public DbSet<ProductDetail> ProductDetails { get; set; }
    public DbSet<ProductSize> ProductSizes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<ProductColor>()
           .HasOne(pc => pc.ProductDetail)
           .WithMany(pd => pd.ProductColors)
           .HasForeignKey(pc => pc.ProductDetailId);

        modelBuilder.Entity<ProductSize>()
            .HasOne(ps => ps.ProductDetail)
            .WithMany(pd => pd.ProductSizes)
            .HasForeignKey(ps => ps.ProductDetailId);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.ProductDetail)
            .WithOne(pd => pd.Product)
            .HasForeignKey<ProductDetail>(pd => pd.ProductId);

        base.OnModelCreating(modelBuilder);
    }
}
