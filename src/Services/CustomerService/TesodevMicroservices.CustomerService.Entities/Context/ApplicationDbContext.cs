using Microsoft.EntityFrameworkCore;
using TesodevMicroservices.CustomerService.Entities.Entity;
using TesodevMicroservices.CustomerService.Entities.EntityConfiguration;

namespace TesodevMicroservices.CustomerService.Entities.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerEntityConfiguration()); 
            base.OnModelCreating(modelBuilder);
        }
    }
}