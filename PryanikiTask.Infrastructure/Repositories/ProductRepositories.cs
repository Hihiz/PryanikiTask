using Microsoft.EntityFrameworkCore;
using PryanikiTask.Application.Interfaces;
using PryanikiTask.Domain.Entities;

namespace PryanikiTask.Infrastructure.Repositories
{
    public class ProductRepositories : IBaseRepository<Product>
    {
        private readonly IApplicationDbContext _db;

        public ProductRepositories(IApplicationDbContext db) => _db = db;

        public async Task<List<Product>> GetAll(CancellationToken cancellationToken = default) => await _db.Products
            .AsNoTracking()
            .Include(p => p.Order)
            .OrderBy(p => p.Id)
            .ToListAsync(cancellationToken);

        public async Task<Product> GetById(int id, CancellationToken cancellationToken = default) => await _db.Products
            .AsNoTracking()
            .Include(p => p.Order)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        public async Task<Product> Create(Product entity, CancellationToken cancellationToken = default)
        {
            await _db.Products.AddAsync(entity, cancellationToken);

            await _db.Products.Entry(entity).Reference(w => w.Order).LoadAsync(cancellationToken);

            return entity;
        }

        public async Task<Product> Update(Product entity, CancellationToken cancellationToken = default)
        {
            _db.Products.Update(entity);

            await _db.Products.Entry(entity).Reference(w => w.Order).LoadAsync(cancellationToken);

            return entity;
        }

        public async Task Delete(Product entity) => _db.Products.Remove(entity);

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await _db.SaveChangesAsync(cancellationToken);
    }
}
