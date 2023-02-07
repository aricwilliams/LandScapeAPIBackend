using LandScapeAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LandScapeAPI.Utility
{
    public class ProductDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<HomePageCard> Products { get; set; }
        public DbSet<CustomerDetails> CustomerDetails { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<HomePageCard> HomePageCard { get; set; }
        public DbSet<Labels> Labels { get; set; }


        public ProductDbContext(DbContextOptions<ProductDbContext> options)
       : base(options)
        {
        }
      
    }

}
