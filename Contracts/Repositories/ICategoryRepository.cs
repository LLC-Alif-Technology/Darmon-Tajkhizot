using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Category;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface ICategoryRepository: IRepositoryBase<Category>
    {
        Task<CategoryResponse> GetCategory(Guid id);
        Task<CategoryResponse> GetCategoryResponseByIdAsync(Guid id, bool trackChanges);
        Task<IEnumerable<CategoryResponse>> GetAllAsync(bool trackChanges);
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);
        Task<Category> GetByIdAsync(Guid id, bool trackChanges);
    }
}
