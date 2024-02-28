using Kipuh.API.Kipuh.Inventory.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kipuh.API.Kipuh.Shared;

public class AppDbContext : DbContext
{
    public DbSet<Product>? Products { get; set; }
    
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Product
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<Product>().HasKey(product => product.Id);
        modelBuilder.Entity<Product>().Property(product => product.Id).IsRequired().ValueGeneratedOnAdd();
        modelBuilder.Entity<Product>().Property(product => product.Description);
        modelBuilder.Entity<Product>().Property(product => product.Name);
        modelBuilder.Entity<Product>().Property(product => product.Stock);
    }
}