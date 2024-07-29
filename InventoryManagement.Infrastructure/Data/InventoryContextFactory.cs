using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InventoryManagement.Infrastructure.Data;

public class InventoryContextFactory : IDesignTimeDbContextFactory<InventoryContext>
{
    public InventoryContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();

        // Configure a string de conexão aqui
        optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=controlStock;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;");

        return new InventoryContext(optionsBuilder.Options);
    }
}