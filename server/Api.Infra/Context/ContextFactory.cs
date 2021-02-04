using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Infra.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApiContext>
    {
        public ApiContext CreateDbContext(string[] args)
        {
            var connectionString = "Data Source=../Api.Application/database.sqlite";
            var optionsBuilder = new DbContextOptionsBuilder<ApiContext>();
            optionsBuilder.UseSqlite(connectionString);
            
            return new ApiContext(optionsBuilder.Options);
        }
    }
}