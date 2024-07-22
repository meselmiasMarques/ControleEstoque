using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<List<T>> GetAsync();
        Task<T> GetAsyncById(int id);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }


}
