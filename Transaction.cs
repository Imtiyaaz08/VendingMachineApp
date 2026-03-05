using Microsoft.EntityFrameworkCore;
using VendingMachine.API.Models;

namespace VendingMachine.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<InventoryChangeLog> InventoryChangeLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional model configurations can be added here

            // Seed dummy data if using InMemory provider
            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.InMemory")
            {
                modelBuilder.Entity<Item>().HasData(
                    new Item { Id = 1, Name = "Coke", Price = 1.50m, Stock = 10 },
                    new Item { Id = 2, Name = "Pepsi", Price = 1.25m, Stock = 8 },
                    new Item { Id = 3, Name = "Water", Price = 1.00m, Stock = 15 },
                    new Item { Id = 4, Name = "Chips", Price = 1.75m, Stock = 5 },
                    new Item { Id = 5, Name = "Candy", Price = 0.75m, Stock = 20 }
                );
                modelBuilder.Entity<Transaction>().HasData(
                    new Transaction { Id = 1, ItemId = 1, Amount = 2.00m, PurchaseDate = System.DateTime.UtcNow },
                    new Transaction { Id = 2, ItemId = 2, Amount = 1.50m, PurchaseDate = System.DateTime.UtcNow },
                    new Transaction { Id = 3, ItemId = 3, Amount = 1.00m, PurchaseDate = System.DateTime.UtcNow }
                );
                modelBuilder.Entity<InventoryChangeLog>().HasData(
                    new InventoryChangeLog { Id = 1, ItemId = 1, ChangeType = "Added", Timestamp = System.DateTime.UtcNow },
                    new InventoryChangeLog { Id = 2, ItemId = 2, ChangeType = "Added", Timestamp = System.DateTime.UtcNow },
                    new InventoryChangeLog { Id = 3, ItemId = 3, ChangeType = "Added", Timestamp = System.DateTime.UtcNow },
                    new InventoryChangeLog { Id = 4, ItemId = 4, ChangeType = "Added", Timestamp = System.DateTime.UtcNow },
                    new InventoryChangeLog { Id = 5, ItemId = 5, ChangeType = "Added", Timestamp = System.DateTime.UtcNow }
                );
            }
        }
    }
}