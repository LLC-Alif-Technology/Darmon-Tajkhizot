using Contracts;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataContexts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            services.AddDbContext<DataContext>(optionsAction => optionsAction.UseNpgsql(configuration.GetConnectionString("PostgresCS")).UseLazyLoadingProxies(false));
        
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();

        public static void ConfigureDIs(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IFileService, FileService>();
        }
    }
}
