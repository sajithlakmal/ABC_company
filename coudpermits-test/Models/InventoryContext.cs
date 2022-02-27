using Microsoft.EntityFrameworkCore;

namespace coudpermits_test.Models
{
    public class InventoryContext : DbContext
    {

        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
        }

        public DbSet<Inventory> Inventory { get; set; }


    }
}
