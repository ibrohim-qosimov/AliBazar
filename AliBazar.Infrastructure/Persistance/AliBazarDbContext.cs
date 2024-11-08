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

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrdersItem { get; set; }
}
