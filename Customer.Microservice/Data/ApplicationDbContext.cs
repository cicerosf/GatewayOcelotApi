using Microsoft.EntityFrameworkCore;
using CustomerMicroservice.Entities;

namespace CustomerMicroservice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
