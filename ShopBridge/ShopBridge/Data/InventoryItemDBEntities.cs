using ShopBridge.Models;
using System.Data.Entity;

namespace ShopBridge.Data
{
    /// <summary>
    /// DBContent class for inventory systems
    /// </summary>
    
    public class InventoryItemDBEntities : DbContext
    {
        public InventoryItemDBEntities() : base("DefaultConnection")
        {

        }

        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<InventoryItemDBEntities>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}