using AtendimentoApplication.Abstractions.Application;
using AtendimentoApplication.Services;
using AtendimentoInfra.Context;
using AtendimentoInfra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AtendimentoApi.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependencyInjection(this IServiceCollection services)
        {
            //Service
            services.AddScoped<IAtendimentoService, AtendimentoService>();

            //Repository
            services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("ApplicationConnection"),
                    assembly => assembly.MigrationsAssembly(typeof(ApplicationDbContext)
                    .Assembly.FullName));
            });

            return services;
        }

        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(policy =>
            {
                policy.AddPolicy("OpenCorsPolicy", opt =>
                {
                    opt
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}
