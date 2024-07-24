using InventoryManagement.Application.Repositories.Interfaces;
using InventoryManagement.Application.Services.Interfaces;
using InventoryManagement.Domain.Entities;


namespace InventoryManagement.Application.Services
{
    public class CategoryService : IService<Category>
    {
        private readonly IRepository<Category> _repository;
        public CategoryService(IRepository<Category> repository)
            => _repository = repository;

        public async Task<Category> Add(Category entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Erro nos dados preenchidos");

            }

            try
            {
                var category = await _repository.AddAsync(entity);

                return category;
            }
            catch (Exception e)
            {
                throw new ArgumentNullException(nameof(entity), e.Message);

            }

        }

        public async Task<Category> Get(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id não encontrado");
            }

            try
            {
             var category = await _repository.GetAsyncById(id);
             return category;
            }
            catch (Exception e)
            {
                throw new ArgumentNullException(e.Message);
            }
        }

        public async Task<Category> Update(Category entity)
        {
            if (entity.CategoryId <= 0)
            {
                throw new ArgumentException("Invalid category ID.", nameof(entity.CategoryId));
            }

            try
            {
                var category = await _repository.GetAsyncById(entity.CategoryId);

                if (category == null)
                {
                    throw new ArgumentNullException("categoria não encontrado");
                }

                category.Name = entity.Name;

                await _repository.UpdateAsync(category);
                return category;


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Category>> GetAll()
        {
            try
            {
                var categories = await _repository.GetAsync();
                return categories;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Category> Delete(Category entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Category não encontrada");
            }

            try
            {
                var category = await _repository.GetAsyncById(entity.CategoryId);
                if (category == null)
                {
                    throw new ArgumentNullException(nameof(entity), "Category não encontrada");

                }

                await _repository.DeleteAsync(category);
                return category;

            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(nameof(entity), ex.Message);

            }

        }
    }
}
