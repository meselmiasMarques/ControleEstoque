using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Data
{
    public class InventoryContext : DbContext
    {

        public InventoryContext(DbContextOptions options)
        :base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração de Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .HasMaxLength(500);

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.QuantityInStock)
                    .IsRequired();

                entity.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(p => p.StockMovements)
                    .WithOne(sm => sm.Product)
                    .HasForeignKey(sm => sm.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuração de Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasMany(c => c.Products)
                    .WithOne(p => p.Category)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuração de Supplier
            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.HasKey(e => e.SupplierID);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ContactName)
                    .HasMaxLength(100);

                entity.Property(e => e.Address)
                    .HasMaxLength(250);

                entity.Property(e => e.City)
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20);
            });

            // Configuração de Customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasKey(e => e.CustomerID);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ContactName)
                    .HasMaxLength(100);

                entity.Property(e => e.Address)
                    .HasMaxLength(250);

                entity.Property(e => e.City)
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20);
            });

            // Configuração de StockMovement
            modelBuilder.Entity<StockMovement>(entity =>
            {
                entity.ToTable("StockMovement");

                entity.HasKey(e => e.StockMovementId);

                entity.Property(e => e.Quantity)
                    .IsRequired();

                entity.Property(e => e.MovementDate)
                    .IsRequired()
                    .HasColumnType("datetime");

                entity.Property(e => e.MovementType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(sm => sm.Product)
                    .WithMany(p => p.StockMovements)
                    .HasForeignKey(sm => sm.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(sm => sm.Customer)
                    .WithMany()
                    .HasForeignKey(sm => sm.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sm => sm.Supplier)
                    .WithMany()
                    .HasForeignKey(sm => sm.SupplierId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuração de Order
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.OrderDate)
                    .IsRequired()
                    .HasColumnType("datetime");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(18,2)");

                entity.HasOne(o => o.Customer)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(o => o.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(o => o.OrderDetails)
                    .WithOne(od => od.Order)
                    .HasForeignKey(od => od.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuração de OrderDetail
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.HasKey(e => e.OrderDetailId);

                entity.Property(e => e.Quantity)
                    .IsRequired();

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(18,2)");

                entity.HasOne(od => od.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(od => od.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(od => od.Order)
                    .WithMany(o => o.OrderDetails)
                    .HasForeignKey(od => od.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
