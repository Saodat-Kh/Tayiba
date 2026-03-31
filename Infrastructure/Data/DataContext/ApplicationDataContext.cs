using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDataContext(DbContextOptions<ApplicationDataContext> options)
    : IdentityDbContext<AppUser, IdentityRole<int>, int>(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ItemProduct> ItemProducts { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<ProductVariant>  ProductVariants { get; set; }
  
    public DbSet<Financy>  Financies { get; set; }
 
}