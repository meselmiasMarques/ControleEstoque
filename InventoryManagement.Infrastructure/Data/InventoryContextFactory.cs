using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InventoryManagement.Infrastructure.Data;

public class InventoryContextFactory : IDesignTimeDbContextFactory<InventoryContext>
{
    public InventoryContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();

        // Configure a string de conexão aqui
        optionsBuilder.UseSqlite("Data Source=inventory.db");

        return new InventoryContext(optionsBuilder.Options);
    }
}