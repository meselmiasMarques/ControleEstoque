using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryManagement.Application.Repositories.Interfaces;
using InventoryManagement.Application.Services.Interfaces;
using InventoryManagement.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace InventoryManagement.Application.Services
{
    public class ProductService : IService<Product>
    {
        private readonly IRepository<Product> _repository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IRepository<Product> repository, ILogger<ProductService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Product> Add(Product entity)
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
                _logger.LogError(ex, "An error occurred while adding a product.");
                throw;
            }
        }

        public async Task<Product> Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid product ID.", nameof(id));
            }

            try
            {
                return await _repository.GetAsyncById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving product with ID {id}.");
                throw;
            }
        }

        public async Task<Product> Update(Product entity)
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
                _logger.LogError(ex, "An error occurred while updating a product.");
                throw;
            }
        }

        public async Task<List<Product>> GetAll()
        {
            try
            {
                return await _repository.GetAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all products.");
                throw;
            }
        }

        public async Task<Product> Delete(Product entity)
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
                _logger.LogError(ex, "An error occurred while deleting a product.");
                throw;
            }
        }
    }
}
