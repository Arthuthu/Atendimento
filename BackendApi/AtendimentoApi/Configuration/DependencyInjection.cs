using AtendimentoInfra.Context;
using Microsoft.EntityFrameworkCore;

namespace AtendimentoApi.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependencyInjection(this IServiceCollection services)
        {
            //AppService
            // services.AddScoped<IUserAppService, UserAppService>();

            //Repository
            //services.AddScoped<IUserRepository, UserRepository>();

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
