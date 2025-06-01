using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace PetCareApplication.Infrastructure.DbContexts
{
    public class PetCareDbContextFactory : IDesignTimeDbContextFactory<PetCareApplicationDbContext>
    {
        public PetCareApplicationDbContext CreateDbContext(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("PetCareDb");

            var optionsBuilder = new DbContextOptionsBuilder<PetCareApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString, options =>
                options.MigrationsAssembly("PetCareApplication"));

            return new PetCareApplicationDbContext(optionsBuilder.Options);
        }
    }
}
