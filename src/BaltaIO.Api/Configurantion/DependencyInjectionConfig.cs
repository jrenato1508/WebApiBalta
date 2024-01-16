using BaltaIO.Business.Interface;
using BaltaIO.Data.Context;
using BaltaIO.Data.Repository;

namespace BaltaIO.Api.Configurantion
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<BaltaDbContext>();
            services.AddScoped<IibgeRepository, IBGERepository>();

            return services;
        }
    }
}
