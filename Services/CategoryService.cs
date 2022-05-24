using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects.Category;
using Entities.DataTransferObjects.Features;
using Entities.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IFileService _fileService;
        public CategoryService(IRepositoryManager repositoryManager, IFileService fileService)
        {
            _fileService = fileService;
            _repositoryManager = repositoryManager;

        }

        public async Task<IEnumerable<CategoryResponse>> GetAllAsync()
        {
            var categories = await _repositoryManager.CategoryRepository.GetAllCategoriesAsync(false);
            var superCategories = categories.Where(x => x.ParentCategoryId == null).ToList();
            foreach (var superCategory in superCategories)
            {
                await GetSubCategories(superCategory, categories);
            }
            return superCategories.Select(x => x.ToCategoryResponse());
        }

        private static async Task GetSubCategories(Category category, IEnumerable<Category> categories)
        {
            category.SubCategories = categories.Where(x => x.ParentCategoryId == category.Id).ToList();
            foreach (var superCategory in category.SubCategories)
            {
                await GetSubCategories(superCategory, categories);
            }
        }

        public async Task<CategoryResponse> GetByIdAsync(Guid id, bool trackChanges)
        {
            return await _repositoryManager.CategoryRepository.GetCategoryResponseByIdAsync(id, false);
        }

        public async Task<CategoryResponse> GetCategory(Guid id)
        {
            return await _repositoryManager.CategoryRepository.GetCategory(id);
        }

        public async Task<Guid> CreateAsync(CreateCategoryRequest request)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                IsPopular = request.IsPopular ?? false,
                ParentCategoryId = request.ParentCategoryId
            };
            if (request.Icon != null)
                category.IconPath = await _fileService.AddFileAsync(request.Icon, FileTypes.Icon, nameof(Category));
            if (request.Image != null)
                category.ImagePath = await _fileService.AddFileAsync(request.Image, FileTypes.Image, nameof(Category));
            await _repositoryManager.CategoryRepository.CreateAsync(category);
            await _repositoryManager.SaveAsync();
            return category.Id;
        }

        public async Task<Guid> DeleteByIdAsync(Guid id)
        {
            var category = await _repositoryManager.CategoryRepository.GetByIdAsync(id, false);
            _fileService.DeleteFile(category.IconPath);
            _repositoryManager.CategoryRepository.Delete(category);
            await _repositoryManager.SaveAsync();
            return category.Id;
        }

        public async Task UpdateAsync(Guid id, UpdateCategoryRequest request)
        {
            var category = await _repositoryManager.CategoryRepository.GetByIdAsync(id, false);
            category.Name = request.Name;
            category.ParentCategoryId = request.ParentCategoryId;
            category.IsPopular = request.IsPopular ?? category.IsPopular;
            if (request.Image != null)
            {
                _fileService.DeleteFile(category.ImagePath);
                var imagePath = await _fileService.AddFileAsync(request.Image, FileTypes.Image, nameof(Category));
                category.ImagePath = imagePath;
            }
            if (request.Icon != null)
            {
                _fileService.DeleteFile(category.IconPath);
                var iconPath = await _fileService.AddFileAsync(request.Icon, FileTypes.Icon, nameof(Category));
                category.IconPath = iconPath;
            }
            _repositoryManager.CategoryRepository.Update(category);
            await _repositoryManager.SaveAsync();
        }
    }
}
