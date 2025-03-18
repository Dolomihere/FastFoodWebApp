using Assignment_NET104.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_NET104.DataContext
{
    public class WebContext : DbContext
    {
        public WebContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configure columns, key

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(a => a.AdminId);

                entity.Ignore(a => a.CheckPassword);

                entity.Property(a => a.Name)
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(a => a.Email)
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(a => a.Password)
                    .HasColumnType("varchar(20)")
                    .HasMaxLength(20)
                    .IsRequired();
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.CustomerId);

                entity.Ignore(c => c.CheckPassword);

                entity.Property(c => c.Name)
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(c => c.Email)
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(c => c.Password)
                    .HasColumnType("varchar(20)")
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property(c => c.StreetAddress)
                    .HasColumnType("nvarchar(200)")
                    .HasMaxLength(200)
                    .IsRequired();

                entity.Property(c => c.City)
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100)
                    .IsRequired();
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(c => c.CartId);

                entity.Property(c => c.SessionId)
                    .HasColumnType("varchar(40)")
                    .HasMaxLength(10);

                entity.Property(c => c.CreatedDate)
                    .HasColumnType("datetime")
                    .IsRequired();

                entity.Property(c => c.UpdatedDate)
                    .HasColumnType("datetime")
                    .IsRequired();
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(ci => ci.CartItemId);

                entity.Property(ci => ci.Quantity)
                    .HasColumnType("int")
                    .IsRequired();

                entity.Property(ci => ci.Price)
                    .HasColumnType("decimal(18,3)")
                    .HasPrecision(18, 3)
                    .IsRequired();
            });

            modelBuilder.Entity<FoodItem>(entity =>
            {
                entity.HasKey(f => f.FoodItemId);

                entity.Ignore(f => f.ImageFile);

                entity.Property(f => f.Name)
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(f => f.Category)
                    .HasColumnType("int")
                    .HasConversion<int>()
                    .IsRequired();

                entity.Property(f => f.ImagePath)
                    .HasColumnType("nvarchar(260)")
                    .HasMaxLength(260);

                entity.Property(f => f.Price)
                    .HasColumnType("decimal(18,3)")
                    .HasPrecision(18, 3)
                    .IsRequired();

                entity.Property(f => f.Status)
                    .HasColumnType("int")
                    .HasConversion<int>()
                    .IsRequired();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.OrderId);

                entity.Property(o => o.StreetAddress)
                    .HasColumnType("nvarchar(200)")
                    .HasMaxLength(200)
                    .IsRequired();

                entity.Property(o => o.City)
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(o => o.CreatedDate)
                    .HasColumnType("datetime")
                    .IsRequired();

                entity.Property(o => o.Status)
                    .HasColumnType("int")
                    .HasConversion<int>()
                    .IsRequired();
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(od => od.OrderItemId);

                entity.Ignore(a => a.Total);

                entity.Property(od => od.Quantity)
                    .HasColumnType("int")
                    .IsRequired();

                entity.Property(od => od.Price)
                    .HasColumnType("decimal(18,3)")
                    .HasPrecision(18, 3)
                    .IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.SessionId);

                entity.Property(u => u.SessionId)
                    .HasColumnType("varchar(40)")
                    .IsRequired();

                entity.Property(u => u.ExpireDate)
                    .HasColumnType("datetime")
                    .IsRequired();
            });

            //RelationShip

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasOne(c => c.Cart)
                    .WithOne(cart => cart.Customer)
                    .HasForeignKey<Cart>(cart => cart.CustomerId)
                    .IsRequired(false);

                entity.HasMany(c => c.Orders)
                    .WithOne(o => o.Customer)
                    .HasForeignKey(o => o.CustomerId)
                    .IsRequired();
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasMany(c => c.CartItems)
                    .WithOne(ci => ci.Cart)
                    .HasForeignKey(ci => ci.CartId)
                    .IsRequired();
            });

            modelBuilder.Entity<FoodItem>(entity => 
            {
                entity.HasMany(fi => fi.OrderDetails)
                    .WithOne(od => od.FoodItem)
                    .HasForeignKey(od => od.FoodItemId)
                    .IsRequired();

                entity.HasMany(fi => fi.CartItems)
                    .WithOne(ci => ci.FoodItem)
                    .HasForeignKey(ci => ci.FoodItemId)
                    .IsRequired();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasMany(o => o.OrderDetails)
                    .WithOne(od => od.Order)
                    .HasForeignKey(od => od.OrderId)
                    .IsRequired();
            });
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<OrderItem> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
