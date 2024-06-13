using PryanikiTask.Application.Interfaces;
using PryanikiTask.Domain.Entities;

namespace PryanikiTask.Infrastructure.Data
{
    public static class SeedData
    {
        public static async void Initialize(IApplicationDbContext db)
        {
            if (db.Orders.Any())
            {
                return;
            }

            await db.Orders.AddRangeAsync(
                new Order
                {
                    Id = 1,
                    Description = "Заказ1",
                    CreatedAt = DateTime.Now,
                },
                 new Order
                 {
                     Id = 2,
                     CreatedAt = DateTime.Now,
                 });

            if (db.Products.Any())
            {
                return;
            }

            await db.Products.AddRangeAsync(
                new Product
                {
                    Id = 1,
                    Title = "Product1",
                    Price = 1100,
                    OrderId = 1
                },
                  new Product
                  {
                      Id = 2,
                      Title = "Product2",
                      Price = 100,
                      OrderId = 1
                  },
                    new Product
                    {
                        Id = 3,
                        Title = "Product3",
                        Price = 500,
                        OrderId = 2
                    },
                    new Product
                    {
                        Id = 4,
                        Title = "Product4",
                        Price = 1000,
                        OrderId = 2
                    });

            await db.SaveChangesAsync(new CancellationToken());
        }
    }
}
