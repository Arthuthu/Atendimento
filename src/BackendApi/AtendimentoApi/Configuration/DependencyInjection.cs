using AtendimentoApi.AutoMapper;
using AtendimentoApplication.Abstractions.Application;
using AtendimentoApplication.Abstractions.Repository;
using AtendimentoApplication.Services;
using AtendimentoInfra.Context;
using AtendimentoInfra.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AtendimentoApi.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependencyInjection(this IServiceCollection services)
        {
            //Service
            services.AddScoped<IAtendimentoService, AtendimentoService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();

            //Repository
            services.AddScoped<IAtendimentoRepository, AtendimentoRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();

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

        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainToResponseProfile());
                mc.AddProfile(new RequestToDomainProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

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
