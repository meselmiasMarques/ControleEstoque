using InventoryManagement.Application.Repositories.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Domain.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly InventoryContext _dbContext;

        public ProductRepository(InventoryContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Product> AddAsync(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _dbContext.Products.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Product>> GetAsync()
        {
            return await _dbContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetAsyncById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid product ID.", nameof(id));
            }

            return await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(x => x.ProductId == id) ?? new Product();
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Products.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Products.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
