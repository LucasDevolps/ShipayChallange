using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ShipayChallange.Infrastructure.Persistence;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    private const string _connectionString = "Server=localhost,1433;Database=shipayChallangeDb;User Id=sa;Password=FKxjHE4tNOVTvk76MFp95dZz2Ixm;TrustServerCertificate=True";
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseSqlServer(_connectionString);

        return new AppDbContext(optionsBuilder.Options);
    }
}
