using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects.Product;
using Entities.Models;
using Entities.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enums;
namespace Services
{
    public class ProductService:IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IFileService _fileService;
        public ProductService(IRepositoryManager repositoryManager, IFileService fileService)
        {
            _repositoryManager = repositoryManager;
            _fileService = fileService;
        }

        public async Task<Guid> CreateAsync(CreateProductRequest request)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                CategoryId = request.CategoryId,
                Price = request.Price,
                Description = request.Description,
                Discount = request.Discount,
                Quantity = request.Quantity,
            };
            if (request.Image != null)
                product.ImagePath = await _fileService.AddFileAsync(request.Image, FileTypes.Image, nameof(Product));
            await _repositoryManager.ProductRepository.CreateAsync(product);
            await _repositoryManager.SaveAsync();
            return product.Id;
        }

        //public async Task<List<GetAllProductsResponse>> GetAllAsync(string searchString)
        //{
        //    return await _repositoryManager.ProductRepository.GetAllAsync(false, searchString);
        //}
        public async Task<List<GetAllProductsResponse>> GetAllAsync(string searchString, int? pageNumber, int pagesize)
        {
            var products = await _repositoryManager.ProductRepository.GetAllAsync(false,searchString);
            products = PaginatedList<GetAllProductsResponse>.Create(products.AsQueryable(), pageNumber ?? 1, pagesize);
            return products;
        }

    }
}
