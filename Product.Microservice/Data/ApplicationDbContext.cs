using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Entities;

namespace ProductMicroservice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
