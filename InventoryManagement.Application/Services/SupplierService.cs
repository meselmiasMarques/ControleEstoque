using InventoryManagement.Application.Repositories.Interfaces;
using InventoryManagement.Application.Services.Interfaces;
using InventoryManagement.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace InventoryManagement.Application.Services
{
    public class SupplierService : IService<Supplier>
    {
        private readonly IRepository<Supplier> _repository;
        private readonly ILogger<SupplierService> _logger;

        public SupplierService(IRepository<Supplier> repository, ILogger<SupplierService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Supplier> Add(Supplier entity)
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
                _logger.LogError(ex, "An error occurred while adding a supplier.");
                throw;
            }
        }

        public async Task<Supplier> Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid supplier ID.", nameof(id));
            }

            try
            {
                return await _repository.GetAsyncById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving supplier with ID {id}.");
                throw;
            }
        }

        public async Task<Supplier> Update(Supplier entity)
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
                _logger.LogError(ex, "An error occurred while updating a supplier.");
                throw;
            }
        }

        public async Task<List<Supplier>> GetAll()
        {
            try
            {
                return await _repository.GetAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all suppliers.");
                throw;
            }
        }

        public async Task<Supplier> Delete(Supplier entity)
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
                _logger.LogError(ex, "An error occurred while deleting a supplier.");
                throw;
            }
        }
    }
}
