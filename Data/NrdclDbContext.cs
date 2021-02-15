using Microsoft.EntityFrameworkCore;
using Assignment_NRDCL.Models;

namespace Assignment_NRDCL.Data
{
    public class NrdclDbContext : DbContext
    {
        public NrdclDbContext(DbContextOptions<NrdclDbContext> options) : base(options)
        {  
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
