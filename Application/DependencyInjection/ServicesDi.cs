using Microsoft.Extensions.DependencyInjection;
using Domain.Services;

namespace Application.DependencyInjection
{
    public class ServicesDi
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ProductServices>();
        }
    }
}

