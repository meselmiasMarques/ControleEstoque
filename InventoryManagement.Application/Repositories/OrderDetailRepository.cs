using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryManagement.Application.Repositories.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Domain.Repositories
{
    public class OrderDetailRepository : IRepository<OrderDetail>
    {
        private readonly InventoryContext _dbContext;

        public OrderDetailRepository(InventoryContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<OrderDetail> AddAsync(OrderDetail entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _dbContext.OrderDetails.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<OrderDetail>> GetAsync()
        {
            return await _dbContext.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Product)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<OrderDetail> GetAsyncById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid order detail ID.", nameof(id));
            }

            return await _dbContext.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.OrderDetailId == id) ?? new OrderDetail();
        }

        public async Task<OrderDetail> UpdateAsync(OrderDetail entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.OrderDetails.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(OrderDetail entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.OrderDetails.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
