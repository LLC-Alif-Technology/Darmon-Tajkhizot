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

namespace Services
{
    public class ProductService:IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        public ProductService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<List<GetAllProductsResponse>> GetAllAsync()
        {
            return await _repositoryManager.ProductRepository.GetAllAsync(false);
        }
        //public async Task<List<GetAllProductsResponse>> GetAllAsync(int? pageNumber)
        //{
        //    var products = await _repositoryManager.ProductRepository.GetAllAsync(false);
        //    int pageSize = 5;
        //    products = PaginatedList<GetAllProductsResponse>.Create(products.AsQueryable(), pageNumber ?? 1, pageSize);
        //    return products;
        //}

    }
}
