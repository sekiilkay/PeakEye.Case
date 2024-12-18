using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeakEye.Service.Users;

namespace PeakEye.Service.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServiceExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAccountService, AccountService>();

            return services;
        }
    }
}
