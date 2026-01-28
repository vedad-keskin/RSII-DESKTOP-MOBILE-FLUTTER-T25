using eCommerce.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using System;

namespace eCommerce.Services.Database
{
    public static class DataSeeder
    {
        
        public static void SeedData(this ModelBuilder modelBuilder)
        {

            // --- ROLES ---
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin", Description = "System administrator", CreatedAt = DateTime.Now, IsActive = true },
                new Role { Id = 2, Name = "User", Description = "Regular customer", CreatedAt = DateTime.Now, IsActive = true }
            );

            // --- SALTS ---
            string vedadSalt = PasswordHelper.GenerateSalt();
            string user1Salt = PasswordHelper.GenerateSalt();
            string user2Salt = PasswordHelper.GenerateSalt();
            string user3Salt = PasswordHelper.GenerateSalt();

            // --- USERS ---
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Vedad",
                    LastName = "Keskin",
                    Email = "vedad.keskin@edu.fit.ba",
                    Username = "admin",
                    PasswordHash = PasswordHelper.GenerateHash(vedadSalt, "Test123"),
                    PasswordSalt = vedadSalt,
                    CreatedAt = DateTime.Now,
                    IsActive = true
                },
                new User
                {
                    Id = 2,
                    FirstName = "Jasir",
                    LastName = "Burić",
                    Email = "jasir.buric@edu.fit.ba",
                    Username = "user",
                    PasswordHash = PasswordHelper.GenerateHash(user1Salt, "Test123"),
                    PasswordSalt = user1Salt,
                    CreatedAt = DateTime.Now,
                    IsActive = true
                },
                new User
                {
                    Id = 3,
                    FirstName = "Lejla",
                    LastName = "Mehić",
                    Email = "lejla.mehic@edu.fit.ba",
                    Username = "lejla",
                    PasswordHash = PasswordHelper.GenerateHash(user2Salt, "Test123"),
                    PasswordSalt = user2Salt,
                    CreatedAt = DateTime.Now,
                    IsActive = true
                },
                new User
                {
                    Id = 4,
                    FirstName = "Tarik",
                    LastName = "Begić",
                    Email = "tarik.begic@edu.fit.ba",
                    Username = "tarik",
                    PasswordHash = PasswordHelper.GenerateHash(user3Salt, "Test123"),
                    PasswordSalt = user3Salt,
                    CreatedAt = DateTime.Now,
                    IsActive = true
                }
            );

            // --- USER ROLES ---
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = 1, UserId = 1, RoleId = 1, DateAssigned = DateTime.Now }, // Vedad = Admin
                new UserRole { Id = 2, UserId = 2, RoleId = 2, DateAssigned = DateTime.Now },
                new UserRole { Id = 3, UserId = 3, RoleId = 2, DateAssigned = DateTime.Now },
                new UserRole { Id = 4, UserId = 4, RoleId = 2, DateAssigned = DateTime.Now }
            );

            // --- PRODUCT TYPES ---
            modelBuilder.Entity<ProductType>().HasData(
                new ProductType { Id = 1, Name = "Peripherals", Description = "Computer mice, keyboards, and accessories", CreatedAt = DateTime.Now, IsActive = true },
                new ProductType { Id = 2, Name = "Computers", Description = "Laptops and desktop PCs", CreatedAt = DateTime.Now, IsActive = true },
                new ProductType { Id = 3, Name = "Cases", Description = "Computer chassis and cases", CreatedAt = DateTime.Now, IsActive = true },
                new ProductType { Id = 4, Name = "Monitors", Description = "PC monitors and displays", CreatedAt = DateTime.Now, IsActive = true }
            );

            // --- UNITS OF MEASURE ---
            modelBuilder.Entity<UnitOfMeasure>().HasData(
                new UnitOfMeasure { Id = 1, Name = "Piece", Abbreviation = "pcs", Description = "Single piece", CreatedAt = DateTime.Now, IsActive = true },
                new UnitOfMeasure { Id = 2, Name = "Set", Abbreviation = "set", Description = "Packaged set of items", CreatedAt = DateTime.Now, IsActive = true }
            );

            // --- CATEGORIES ---
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Gaming Gear", Description = "Gaming peripherals and accessories", IsActive = true, CreatedAt = DateTime.Now },
                new Category { Id = 2, Name = "PC Hardware", Description = "Computer components and laptops", IsActive = true, CreatedAt = DateTime.Now }
            );

            // --- PRODUCTS ---
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Razer DeathAdder V2 Mini",
                    Description = "Lightweight ergonomic gaming mouse",
                    Price = 50,
                    StockQuantity = 30,
                    SKU = "RZ-DA-V2M",
                    ProductTypeId = 1,
                    UnitOfMeasureId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    ProductState = "New"
                },
                new Product
                {
                    Id = 2,
                    Name = "ASUS TUF Gaming F15",
                    Description = "Durable gaming laptop with Intel i7 and RTX graphics",
                    Price = 1400,
                    StockQuantity = 12,
                    SKU = "ASUS-TUF15",
                    ProductTypeId = 2,
                    UnitOfMeasureId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    ProductState = "New"
                },
                new Product
                {
                    Id = 3,
                    Name = "NZXT H5 Flow RGB Case",
                    Description = "Mid-tower ATX case with RGB lighting and airflow design",
                    Price = 110,
                    StockQuantity = 20,
                    SKU = "NZXT-H5RGB",
                    ProductTypeId = 3,
                    UnitOfMeasureId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    ProductState = "New"
                },
                new Product
                {
                    Id = 4,
                    Name = "Samsung Odyssey G6 240Hz",
                    Description = "High-refresh curved QHD gaming monitor",
                    Price = 700,
                    StockQuantity = 10,
                    SKU = "SAM-G6-240",
                    ProductTypeId = 4,
                    UnitOfMeasureId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    ProductState = "New"
                }
            );

            // --- PRODUCT CATEGORIES ---
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { Id = 1, ProductId = 1, CategoryId = 1 },
                new ProductCategory { Id = 2, ProductId = 2, CategoryId = 2 },
                new ProductCategory { Id = 3, ProductId = 3, CategoryId = 2 },
                new ProductCategory { Id = 4, ProductId = 4, CategoryId = 1 }
            );

            // --- ASSETS ---
            modelBuilder.Entity<Asset>().HasData(
                new Asset
                {
                    Id = 1,
                    FileName = "1.png",
                    ContentType = "image/png",
                    Base64Content = ImageConversion.ConvertImageToBase64String("Assets", "1.png"),
                    ProductId = 1,
                    CreatedAt = DateTime.Now
                },
                new Asset
                {
                    Id = 2,
                    FileName = "2.png",
                    ContentType = "image/png",
                    Base64Content = ImageConversion.ConvertImageToBase64String("Assets", "2.png"),
                    ProductId = 2,
                    CreatedAt = DateTime.Now
                },
                new Asset
                {
                    Id = 3,
                    FileName = "3.png",
                    ContentType = "image/png",
                    Base64Content = ImageConversion.ConvertImageToBase64String("Assets", "3.png"),
                    ProductId = 3,
                    CreatedAt = DateTime.Now
                },
                new Asset
                {
                    Id = 4,
                    FileName = "4.png",
                    ContentType = "image/png",
                    Base64Content = ImageConversion.ConvertImageToBase64String("Assets", "4.png"),
                    ProductId = 4,
                    CreatedAt = DateTime.Now
                }
            );

            // --- ACTIVITY ---
            modelBuilder.Entity<ActivityIB180079>().HasData(
                new ActivityIB180079 { Id = 1, Name = "Organizacija sastanka", Description = "", DueDate = DateTime.Now.AddDays(5) },
                new ActivityIB180079 { Id = 2, Name = "Izrada prezentacije", Description = "", DueDate = DateTime.Now.AddDays(15) },
                new ActivityIB180079 { Id = 3, Name = "Analiza projekta", Description = "", DueDate = DateTime.Now.AddDays(25) }
            );


            // --- REWARD RULE ---
            modelBuilder.Entity<RewardRuleIB180079>().HasData(
                new RewardRuleIB180079
                {
                    Id = 1,
                    RewardTitle = "Organizacija sastanka - 10 points",
                    NumberOfPoints = 10,
                    ActivityId = 1,
                    MaxDaysToComplete = 5
                },
                new RewardRuleIB180079
                {
                    Id = 2,
                    RewardTitle = "Izrada prezentacije - 20 points",
                    NumberOfPoints = 20,
                    ActivityId = 2,
                    MaxDaysToComplete = 15
                },
                new RewardRuleIB180079
                {
                    Id = 3,
                    RewardTitle = "Analiza projekta - 30 points",
                    NumberOfPoints = 30,
                    ActivityId = 3,
                    MaxDaysToComplete = 25
                }
            );

            // --- USER ACTIVITY ---
            modelBuilder.Entity<UserActivityIB180079>().HasData(
                new UserActivityIB180079 { Id = 1, UserId = 1, DateAssigned = DateTime.Now, ActivityId = 1 , RewardTitle = "Organizacija sastanka - 10 points",CompletedAt = DateTime.Now.AddDays(2),RewardedAt = DateTime.Now.AddDays(2),Note = "Random note", Status = "Completed" },
                 new UserActivityIB180079 { Id = 2, UserId = 2, DateAssigned = DateTime.Now, ActivityId = 2, Note = "Random note", Status = "Cancelled" }
            );

        }
    }
} 