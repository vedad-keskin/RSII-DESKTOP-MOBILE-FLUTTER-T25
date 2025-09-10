using Microsoft.EntityFrameworkCore;

namespace eCommerce.Services.Database
{
    public class eCommerceDbContext : DbContext
    {
        public eCommerceDbContext(DbContextOptions<eCommerceDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<UnitOfMeasure> UnitsOfMeasure { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User entity
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
                
            // Configure Product entity
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name);
                
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.SKU)
                .IsUnique()
                .HasFilter("[SKU] IS NOT NULL");
                
            // Configure Product-Asset relationship
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Assets)
                .WithOne(a => a.Product)
                .HasForeignKey(a => a.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
                
            // Configure Category hierarchy
            modelBuilder.Entity<Category>()
                .HasMany(c => c.ChildCategories)
                .WithOne(c => c.ParentCategory)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
                
            // Configure ProductCategory join entity
            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);
                
            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId);
                
            // Configure Order-OrderItem relationship
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
                
            // Configure User-Order relationship
            modelBuilder.Entity<User>()
                .HasMany<Order>()
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);
                
            // Configure User-ProductReview relationship
            modelBuilder.Entity<User>()
                .HasMany<ProductReview>()
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);
                
            // Configure Product-ProductReview relationship
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Reviews)
                .WithOne(r => r.Product)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
                
            // Configure User-Cart relationship
            modelBuilder.Entity<User>()
                .HasMany<Cart>()
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
                
            // Configure Cart-CartItem relationship
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);
                
            // Configure Product-CartItem relationship
            modelBuilder.Entity<Product>()
                .HasMany(p => p.CartItems)
                .WithOne(ci => ci.Product)
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
                
            // Configure Product-OrderItem relationship
            modelBuilder.Entity<Product>()
                .HasMany(p => p.OrderItems)
                .WithOne(oi => oi.Product)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
                
            // Configure ProductType-Product relationship
            modelBuilder.Entity<ProductType>()
                .HasMany(pt => pt.Products)
                .WithOne(p => p.ProductType)
                .HasForeignKey(p => p.ProductTypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);
                
            // Configure UnitOfMeasure-Product relationship
            modelBuilder.Entity<UnitOfMeasure>()
                .HasMany(u => u.Products)
                .WithOne(p => p.UnitOfMeasure)
                .HasForeignKey(p => p.UnitOfMeasureId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);
                
            // Configure indexes for the new entities
            modelBuilder.Entity<ProductType>()
                .HasIndex(pt => pt.Name)
                .IsUnique();
                
            modelBuilder.Entity<UnitOfMeasure>()
                .HasIndex(u => u.Name)
                .IsUnique();
                
            modelBuilder.Entity<UnitOfMeasure>()
                .HasIndex(u => u.Abbreviation)
                .IsUnique();

            // Configure Role entity
            modelBuilder.Entity<Role>()
                .HasIndex(r => r.Name)
                .IsUnique();

            // Configure UserRole join entity
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            // Create a unique constraint on UserId and RoleId
            modelBuilder.Entity<UserRole>()
                .HasIndex(ur => new { ur.UserId, ur.RoleId })
                .IsUnique();
        }
    }
} 