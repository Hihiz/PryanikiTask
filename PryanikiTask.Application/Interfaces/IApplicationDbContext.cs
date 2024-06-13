using Microsoft.EntityFrameworkCore;
using PryanikiTask.Domain.Entities;

namespace PryanikiTask.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
