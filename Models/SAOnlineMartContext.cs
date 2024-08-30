using Microsoft.EntityFrameworkCore;

namespace SAOnlineMart.Models
{
    // The DbContext class that manages entity objects during runtime.
    public class SAOnlineMartContext : DbContext
    {
        // Constructor to initialize the DbContext with the given options.
        public SAOnlineMartContext(DbContextOptions<SAOnlineMartContext> options)
            : base(options)
        {
        }

        // DbSet properties representing collections of entities in the database.
        // Each DbSet corresponds to a table in the database.
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        // Configures the model and relationships using Fluent API.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define composite key for OrderItem entity using OrderID and ProductID.
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderID, oi.ProductID });

            
            // Call the base class implementation to ensure any configurations in the base class are applied.
            base.OnModelCreating(modelBuilder);
        }
    }
}


