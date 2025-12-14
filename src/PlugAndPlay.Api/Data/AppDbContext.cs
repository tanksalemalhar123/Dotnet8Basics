using Microsoft.EntityFrameworkCore;
using PlugAndPlay.Api.Models;

namespace PlugAndPlay.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users"); // table name in PostgreSQL

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.FullName).HasColumnName("full_name");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.Registered).HasColumnName("registered_");
            });

            modelBuilder.Entity<Product>(entity =>
 {
     entity.ToTable("products");

     entity.Property(e => e.Id).HasColumnName("id");
     entity.Property(e => e.Name).HasColumnName("name");
     entity.Property(e => e.Price).HasColumnName("price");
     entity.Property(e => e.Stock).HasColumnName("stock");
 });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property(e => e.OrderDate).HasColumnName("order_date");

                entity.HasOne(o => o.Product)
                      .WithMany(p => p.Orders)
                      .HasForeignKey(o => o.ProductId);

                entity.HasOne(o => o.User)
                      .WithMany()
                      .HasForeignKey(o => o.UserId);
            });

        }

    }
}
