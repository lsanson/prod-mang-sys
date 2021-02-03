using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Infra.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApiContext>
    {
        public ApiContext CreateDbContext(string[] args)
        {
            var connectionString = "User ID=productApp;Password=prod2020!@#;Server=localhost;Port=5432;Database=productdb;Integrated Security=true;Pooling=true;";
            var optionsBuilder = new DbContextOptionsBuilder<ApiContext>();
            optionsBuilder.UseNpgsql(connectionString);
            
            return new ApiContext(optionsBuilder.Options);
        }
    }
}