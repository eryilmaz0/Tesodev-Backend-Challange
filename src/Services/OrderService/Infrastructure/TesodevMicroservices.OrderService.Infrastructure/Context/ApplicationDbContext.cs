using Microsoft.EntityFrameworkCore;
using TesodevMicroservices.OrderService.Domain.Entity;
using TesodevMicroservices.OrderService.Infrastructure.EntityConfiguration;

namespace TesodevMicroservices.OrderService.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}