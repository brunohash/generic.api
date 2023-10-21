using Microsoft.Extensions.DependencyInjection;
using Application.Factory;

namespace Application.DependencyInjection
{
    public class FactoryDi
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<JwtFactory>();
        }
    }
}

