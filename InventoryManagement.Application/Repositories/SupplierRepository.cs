using InventoryManagement.Application.Repositories.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Domain.Repositories
{
    public class SupplierRepository : IRepository<Supplier>
    {
        private readonly InventoryContext _dbContext;

        public SupplierRepository(InventoryContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Supplier> AddAsync(Supplier entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _dbContext.Suppliers.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Supplier>> GetAsync()
        {
            return await _dbContext.Suppliers.AsNoTracking().ToListAsync();
        }

        public async Task<Supplier> GetAsyncById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid supplier ID.", nameof(id));
            }

            return await _dbContext.Suppliers.AsNoTracking().FirstOrDefaultAsync(x => x.SupplierID == id) ?? new Supplier();
        }

        public async Task<Supplier> UpdateAsync(Supplier entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Suppliers.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Supplier entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Suppliers.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
