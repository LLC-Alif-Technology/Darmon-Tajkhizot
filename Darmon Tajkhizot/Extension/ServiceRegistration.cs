using Contracts;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataContexts;
using LoggerService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using Services;
using System;
using System.Text;
using Microsoft.Extensions.Hosting;

namespace Darmon_Tajkhizot.Extension
{
    public static class ServiceRegistration
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options => options.AddPolicy("DarmonPolicy", builder =>
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader()));

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<DataContext>(optionsAction => optionsAction.UseNpgsql(configuration.GetConnectionString("CUSTOMCONNSTR_PostgresCS")).UseLazyLoadingProxies(false));

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();

        public static void ConfigureDIs(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IBannerService, BannerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IDescriptionService, DescriptionService>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IFileService, FileService>();
        }

        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = env.IsDevelopment()
                ? "Dev mode secret key"
                : Environment.GetEnvironmentVariable("SecretKey");
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                    ValidAudience = jwtSettings.GetSection("validAudience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        }

    }
}
