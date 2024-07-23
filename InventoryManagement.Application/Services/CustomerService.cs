using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryManagement.Application.Repositories.Interfaces;
using InventoryManagement.Application.Services.Interfaces;
using InventoryManagement.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace InventoryManagement.Application.Services
{
    public class CustomerService : IService<Customer>
    {
        private readonly IRepository<Customer> _repository;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(IRepository<Customer> repository, ILogger<CustomerService> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Customer> Add(Customer entity)
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
                _logger.LogError(ex, "An error occurred while adding a customer.");
                throw;
            }
        }

        public async Task<Customer> Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid customer ID.", nameof(id));
            }

            try
            {
                return await _repository.GetAsyncById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving customer with ID {id}.");
                throw;
            }
        }

        public async Task<Customer> Update(Customer entity)
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
                _logger.LogError(ex, "An error occurred while updating a customer.");
                throw;
            }
        }

        public async Task<List<Customer>> GetAll()
        {
            try
            {
                return await _repository.GetAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all customers.");
                throw;
            }
        }

        public async Task<Customer> Delete(Customer entity)
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
                _logger.LogError(ex, "An error occurred while deleting a customer.");
                throw;
            }
        }
    }
}
