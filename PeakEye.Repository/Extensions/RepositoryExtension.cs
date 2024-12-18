using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeakEye.Repository.Context;

namespace PeakEye.Repository.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositoryExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<PeakEyeContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("PostgreSql"));
            });

            return services;
        }
    }
}
