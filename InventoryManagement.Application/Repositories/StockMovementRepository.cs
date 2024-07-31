using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryManagement.Application.Repositories.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Domain.Repositories
{
    public class StockMovementRepository : IStockMovementRepository
    {
        private readonly InventoryContext _dbContext;

        public StockMovementRepository(InventoryContext dbContext) 
            => _dbContext= dbContext;


        public async Task AddAsync(StockMovement movement)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StockMovement>> GetByProductIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

    }
}
