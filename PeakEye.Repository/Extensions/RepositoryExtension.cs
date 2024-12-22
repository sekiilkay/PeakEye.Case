using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeakEye.Repository.Context;
using PeakEye.Repository.Repositories;
using PeakEye.Repository.Vulnerabilities;

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

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IVulnerabilityRepository, VulnerabilityRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
