using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryManagement.Application.Repositories.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Domain.Repositories
{
    public class StockMovementRepository : IRepository<StockMovement>
    {
        private readonly InventoryContext _dbContext;

        public StockMovementRepository(InventoryContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<StockMovement> AddAsync(StockMovement entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _dbContext.StockMovements.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<StockMovement>> GetAsync()
        {
            return await _dbContext.StockMovements
                .Include(sm => sm.Product)
                .Include(sm => sm.Customer)
                .Include(sm => sm.Supplier)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<StockMovement> GetAsyncById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid stock movement ID.", nameof(id));
            }

            return await _dbContext.StockMovements
                .Include(sm => sm.Product)
                .Include(sm => sm.Customer)
                .Include(sm => sm.Supplier)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.StockMovementId == id);
        }

        public async Task<StockMovement> UpdateAsync(StockMovement entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.StockMovements.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(StockMovement entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.StockMovements.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
