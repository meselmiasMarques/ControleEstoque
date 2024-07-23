using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryManagement.Application.Repositories.Interfaces;
using InventoryManagement.Application.Services.Interfaces;
using InventoryManagement.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace InventoryManagement.Application.Services
{
    public class OrderService : IService<Order>
    {
        private readonly IRepository<Order> _repository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IRepository<Order> repository, ILogger<OrderService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Order> Add(Order entity)
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
                _logger.LogError(ex, "An error occurred while adding an order.");
                throw;
            }
        }

        public async Task<Order> Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid order ID.", nameof(id));
            }

            try
            {
                return await _repository.GetAsyncById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving order with ID {id}.");
                throw;
            }
        }

        public async Task<Order> Update(Order entity)
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
                _logger.LogError(ex, "An error occurred while updating an order.");
                throw;
            }
        }

        public async Task<List<Order>> GetAll()
        {
            try
            {
                return await _repository.GetAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all orders.");
                throw;
            }
        }

        public async Task<Order> Delete(Order entity)
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
                _logger.LogError(ex, "An error occurred while deleting an order.");
                throw;
            }
        }
    }
}
