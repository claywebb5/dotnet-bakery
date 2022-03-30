// This file tells the App what framework we're dealing with
using Microsoft.EntityFrameworkCore;
namespace DotnetBakery.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

        // Reference the classes and tables we need
        public DbSet<Baker> Bakers {get; set;}
        public DbSet<Bread> Breads {get; set;}
    }
}