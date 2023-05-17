using BB204_Nest_Web_App.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BB204_Nest_Web_App.DAL;
public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Setting> Settings { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Comment> Comments { get; set; }
}
