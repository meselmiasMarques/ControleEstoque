using InventoryManagement.Application.Repositories.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Domain.Repositories
{
    public class CustomerRepository  : IRepository<Customer>
    {
        private readonly InventoryContext _dbContext;

        public CustomerRepository(InventoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> AddAsync(Customer? entity)
        {
            await _dbContext.Customers.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Customer>> GetAsync()
            => await _dbContext.Customers.AsNoTracking().ToListAsync();


        public async Task<Customer> GetAsyncById(int id)
            => await _dbContext
                .Customers
                .FirstOrDefaultAsync(x => x.CustomerId == id);


        public async Task<Customer> UpdateAsync(Customer entity)
        {
            _dbContext.Customers.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

      

        public async Task DeleteAsync(Customer entity)
        {
            _dbContext.Customers.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
