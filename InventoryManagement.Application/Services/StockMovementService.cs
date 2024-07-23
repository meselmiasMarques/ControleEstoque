using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryManagement.Application.Repositories.Interfaces;
using InventoryManagement.Application.Services.Interfaces;
using InventoryManagement.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace InventoryManagement.Application.Services
{
    public class StockMovementService : IService<StockMovement>
    {
        private readonly IRepository<StockMovement> _repository;
        private readonly ILogger<StockMovementService> _logger;

        public StockMovementService(IRepository<StockMovement> repository, ILogger<StockMovementService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<StockMovement> Add(StockMovement entity)
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
                _logger.LogError(ex, "An error occurred while adding a stock movement.");
                throw;
            }
        }

        public async Task<StockMovement> Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid stock movement ID.", nameof(id));
            }

            try
            {
                return await _repository.GetAsyncById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving stock movement with ID {id}.");
                throw;
            }
        }

        public async Task<StockMovement> Update(StockMovement entity)
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
                _logger.LogError(ex, "An error occurred while updating a stock movement.");
                throw;
            }
        }

        public async Task<List<StockMovement>> GetAll()
        {
            try
            {
                return await _repository.GetAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all stock movements.");
                throw;
            }
        }

        public async Task<StockMovement> Delete(StockMovement entity)
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
                _logger.LogError(ex, "An error occurred while deleting a stock movement.");
                throw;
            }
        }
    }
}
