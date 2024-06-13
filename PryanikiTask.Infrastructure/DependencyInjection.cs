using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PryanikiTask.Application.Interfaces;
using PryanikiTask.Domain.Entities;
using PryanikiTask.Infrastructure.Data;
using PryanikiTask.Infrastructure.Repositories;

namespace PryanikiTask.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                //options.UseNpgsql(connectionString);
                options.UseInMemoryDatabase("InMemory");
            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            SeedData.Initialize(services.BuildServiceProvider().GetService<ApplicationDbContext>());

            services.RepositoriesInit();

            return services;
        }

        public static void RepositoriesInit(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<Order>, OrderRepositories>();
            services.AddScoped<IBaseRepository<Product>, ProductRepositories>();
        }
    }
}
