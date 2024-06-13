using Microsoft.EntityFrameworkCore;
using PryanikiTask.Application.Interfaces;
using PryanikiTask.Domain.Entities;

namespace PryanikiTask.Infrastructure.Repositories
{
    public class OrderRepositories : IBaseRepository<Order>
    {
        private readonly IApplicationDbContext _db;

        public OrderRepositories(IApplicationDbContext db) => _db = db;

        public async Task<List<Order>> GetAll(CancellationToken cancellationToken = default) => await _db.Orders
            .AsNoTracking()
            .Include(o => o.Products)
            .OrderBy(o => o.Id)
            .ToListAsync(cancellationToken);

        public async Task<Order> GetById(int id, CancellationToken cancellationToken = default) => await _db.Orders
            .AsNoTracking()
            .Include(o => o.Products)
           .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        public async Task<Order> Create(Order entity, CancellationToken cancellationToken = default)
        {
            await _db.Orders.AddAsync(entity, cancellationToken);

            return entity;
        }

        public async Task<Order> Update(Order entity, CancellationToken cancellationToken = default)
        {
            _db.Orders.Update(entity);

            return entity;
        }

        public async Task Delete(Order entity) => _db.Orders.Remove(entity);

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await _db.SaveChangesAsync(cancellationToken);
    }
}
