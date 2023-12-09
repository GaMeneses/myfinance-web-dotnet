using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace myfinance_web_dotnet.Infrastructure
{
    public class MyFinanceDbContextFactory
    {
        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<MyFinanceDbContext>
        {
            public MyFinanceDbContext CreateDbContext(string[] args)
            {
                var builder = WebApplication.CreateBuilder(args);
                var configuration = builder.Configuration;
                configuration.SetBasePath(Directory.GetCurrentDirectory());
                configuration.AddJsonFile("appsettings.json");

                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

                var dbContextOptionsBuilder = new DbContextOptionsBuilder<MyFinanceDbContext>();
                dbContextOptionsBuilder.UseSqlServer(connectionString);
                return new MyFinanceDbContext(dbContextOptionsBuilder.Options);
            }
        }
    }
}
