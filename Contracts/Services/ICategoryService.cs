using Entities.DataTransferObjects.Category;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface ICategoryService
    {
        Task<CategoryResponse> GetCategory(Guid id);
        Task<CategoryResponse> GetByIdAsync(Guid id, bool trackChanges);
        Task<IEnumerable<CategoryResponse>> GetAllAsync();
        Task<Guid> CreateAsync(CreateCategoryRequest request);
        Task<Guid> DeleteByIdAsync(Guid id);
        Task UpdateAsync(Guid id, UpdateCategoryRequest request);

    }
}
