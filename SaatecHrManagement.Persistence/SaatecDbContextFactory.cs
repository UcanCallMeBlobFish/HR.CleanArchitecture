using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration.Json; // Ensure this namespace is imported
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SaatecHrManagement.Persistence
{
    public class SaatecDbContextFactory : IDesignTimeDbContextFactory<SaatecDbContext>
    {
        public SaatecDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();


            var optionsBuilder = new DbContextOptionsBuilder<SaatecDbContext>();

            var connectionString = configuration
                        .GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new SaatecDbContext(optionsBuilder.Options);
        }
    }
}
