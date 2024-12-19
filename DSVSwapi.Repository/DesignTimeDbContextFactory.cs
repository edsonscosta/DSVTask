using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DSVSwapi.Repository;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DSVSwapiDBContext>
{
    public DSVSwapiDBContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DSVSwapiDBContext>();

        // Configure a string de conexão para SQL Server no Docker
        optionsBuilder.UseSqlServer(
            "Data Source=localhost,1433;Initial Catalog=DSVSwapiApi;Persist Security Info=True;User ID=sa;Password=DSVSwapiApi@123; MultipleActiveResultSets=True;TrustServerCertificate=True");

        return new DSVSwapiDBContext(optionsBuilder.Options);
    }
}