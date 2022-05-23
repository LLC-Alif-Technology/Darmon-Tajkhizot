using Contracts.Repositories;
using Entities.DataContexts;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Category;
using Entities.DataTransferObjects.Errors;
using Entities.DataTransferObjects.Features;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EfCategoryRepository:RepositoryBase<Category>,ICategoryRepository
    {
        public EfCategoryRepository(DataContext context) : base(context)
        {

        }

        public async Task CreateCategory(Category category) => await CreateAsync(category);
        public async Task<IEnumerable<CategoryResponse>> GetAllAsync(bool trackChanges) => await FindByCondition(x=>x.ParentCategoryId == null, trackChanges).Select(x => x.ToCategoryResponse()).ToListAsync();

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges) => await FindAll(trackChanges).ToListAsync();

        public async Task<Category> GetByIdAsync(Guid id, bool trackChanges) => await FindByCondition(x => x.Id.Equals(id), trackChanges).SingleOrDefaultAsync()
            ?? throw new ExceptionWithStatusCode(HttpStatusCode.NotFound, "Категория с таким Id не найдена");


        public async Task<CategoryResponse> GetCategory(Guid id) =>
            await FindByCondition(c => c.Id.Equals(id), false).AsNoTracking().Select(c => new CategoryResponse
            {
                Id = c.Id,
                Name = c.Name,
                IconPath = c.IconPath,
                SubCategories = c.SubCategories.Select(category => new CategoryResponse
                {
                    Id = category.Id,
                    Name = category.Name,
                    IconPath = category.IconPath
                })
            }).SingleOrDefaultAsync();

        public async Task<CategoryResponse> GetCategoryResponseByIdAsync(Guid id, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(id), trackChanges).Select(c => new CategoryResponse
            {
                Id = c.Id,
                Name = c.Name,
                IconPath = c.IconPath,
                SubCategories = c.SubCategories.Select(category => new CategoryResponse
                {
                    Id = category.Id,
                    Name = category.Name,
                    IconPath = category.IconPath
                })
            }).SingleOrDefaultAsync() ?? throw new ExceptionWithStatusCode(HttpStatusCode.NotFound, "Категория с таким Id не найдена");


        public void GetSubCategories(Guid categoryId,IEnumerable<Category> categories,ref List<Guid> Ids)
        {
            var categoryIds = categories.Where(x => x.ParentCategoryId == categoryId).Select(x => x.Id).ToList();
            Ids.AddRange(categoryIds);
            foreach(var catId in categoryIds)
            {
                GetSubCategories(catId, categories, ref categoryIds);
            }
        }
    }
}
