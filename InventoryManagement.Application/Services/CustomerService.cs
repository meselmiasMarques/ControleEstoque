using InventoryManagement.Application.Repositories.Interfaces;
using InventoryManagement.Application.Services.Interfaces;
using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Application.Services
{
    public class CustomerService : IService<Customer>
    {
        public Task<Customer> Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Delete(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
