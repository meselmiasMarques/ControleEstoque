using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Application.Repositories.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Domain.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly InventoryContext _dbContext;

        public CategoryRepository(InventoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> AddAsync(Category? entity)
        {
            await _dbContext.Categories.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Category>> GetAsync()
            => await _dbContext.Categories.AsNoTracking().ToListAsync();


        public async Task<Category> GetAsyncById(int id)
            => await _dbContext
                .Categories
                .FirstOrDefaultAsync(x => x.CategoryID == id);


        public async Task<Category> UpdateAsync(Category entity)
        {
            _dbContext.Categories.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

      

        public async Task DeleteAsync(Category entity)
        {
            _dbContext.Categories.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
