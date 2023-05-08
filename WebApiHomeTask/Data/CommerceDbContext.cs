using Microsoft.EntityFrameworkCore;
using WebApiHomeTask.Entities;

namespace WebApiHomeTask.Data
{
    public class CommerceDbContext : DbContext
    {
        public CommerceDbContext(DbContextOptions<CommerceDbContext> options)
            :base(options) { }


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
