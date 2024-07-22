using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Application.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Get(int id);
        Task<T> Update(T entity);
        Task<List<T>> GetAll();
        Task<T> Delete(T entity);

    }



}
