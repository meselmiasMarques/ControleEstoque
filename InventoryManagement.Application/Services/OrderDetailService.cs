using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryManagement.Application.Repositories.Interfaces;
using InventoryManagement.Application.Services.Interfaces;
using InventoryManagement.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace InventoryManagement.Application.Services
{
    public class OrderDetailService : IService<OrderDetail>
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly ILogger<OrderDetailService> _logger;

        public OrderDetailService(IRepository<OrderDetail> repository, ILogger<OrderDetailService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<OrderDetail> Add(OrderDetail entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                return await _repository.AddAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding an order detail.");
                throw;
            }
        }

        public async Task<OrderDetail> Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid order detail ID.", nameof(id));
            }

            try
            {
                return await _repository.GetAsyncById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving order detail with ID {id}.");
                throw;
            }
        }

        public async Task<OrderDetail> Update(OrderDetail entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                return await _repository.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating an order detail.");
                throw;
            }
        }

        public async Task<List<OrderDetail>> GetAll()
        {
            try
            {
                return await _repository.GetAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all order details.");
                throw;
            }
        }

        public async Task<OrderDetail> Delete(OrderDetail entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                await _repository.DeleteAsync(entity);
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting an order detail.");
                throw;
            }
        }
    }
}
