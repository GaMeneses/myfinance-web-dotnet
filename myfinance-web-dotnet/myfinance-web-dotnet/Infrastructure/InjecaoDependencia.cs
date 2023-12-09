using myfinance_web_dotnet.Services.Interface;
using myfinance_web_dotnet.Services;
using myfinance_web_dotnet.Controllers.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace myfinance_web_dotnet.Infrastructure
{
    public static class InjecaoDependencia
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            //DbContext
            //services.AddDbContext<MyFinanceDbContext>();
            services.AddDbContext<MyFinanceDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //AutoMap

            services.AddAutoMapper(AssemblyUtil.GetCurrentAssemblies());

            //services
            services.AddTransient<IPlanoContaService, PlanoContaService>();
            services.AddTransient<ITransacaoService, TransacaoService>();
        }
    }
}
