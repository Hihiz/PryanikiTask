using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PryanikiTask.Application.Dto.Orders;
using PryanikiTask.Application.Dto.Products;
using PryanikiTask.Application.Interfaces;
using PryanikiTask.Application.Services;
using PryanikiTask.Application.Validations.FluentValidations.Orders;
using PryanikiTask.Application.Validations.FluentValidations.Products;
using System.Reflection;

namespace PryanikiTask.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

            services.ServicesInit();
            services.FluentValidatorInit();

            return services;
        }

        private static void ServicesInit(this IServiceCollection services)
        {
            services.AddScoped<IBaseService<OrderDto, CreateOrderDto, UpdateOrderDto>, OrderService>();
            services.AddScoped<IBaseService<ProductDto, CreateProductDto, UpdateProductDto>, ProductService>();
        }

        private static void FluentValidatorInit(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateOrderDto>, CreateOrderValidator>();
            services.AddScoped<IValidator<UpdateOrderDto>, UpdateOrderValidator>();

            services.AddScoped<IValidator<CreateProductDto>, CreateProductValidator>();
            services.AddScoped<IValidator<UpdateProductDto>, UpdateProductValidator>();
        }
    }
}
