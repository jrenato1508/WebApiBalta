using BaltaIO.Business.Interface;
using BaltaIO.Business.Notificacoes;
using BaltaIO.Business.Services;
using BaltaIO.Data.Context;
using BaltaIO.Data.Repository;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using static BaltaIO.Api.Configurantion.SwaggerConfig;

namespace BaltaIO.Api.Configurantion
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<BaltaDbContext>();
            services.AddScoped<IibgeRepository, IBGERepository>();
            services.AddScoped<IibgeService, IbgeServices>();
            services.AddScoped<INotificador, Notificador>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
