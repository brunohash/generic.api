using Microsoft.Extensions.DependencyInjection;
using Domain.Business;
using Application.Handlers;

namespace Application.DependencyInjection
{
    public class ServicesDi
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ProductBusiness>();
            services.AddScoped<JwtHandler>();
        }
    }
}

