using myfinance_web_dotnet.Services.Interface;
using myfinance_web_dotnet.Services;
using myfinance_web_dotnet.Controllers.Mappers;

namespace myfinance_web_dotnet.Infrastructure
{
    public static class InjecaoDependencia
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //DbContext
            services.AddDbContext<MyFinanceDbContext>();

            //AutoMap

            services.AddAutoMapper(AssemblyUtil.GetCurrentAssemblies());

            //services
            services.AddTransient<IPlanoContaService, PlanoContaService>();
        }
    }
}
