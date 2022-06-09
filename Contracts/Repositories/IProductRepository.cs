using Entities.DataTransferObjects.Product;
using Entities.DataTransferObjects.Product.Filtration;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IProductRepository:IRepositoryBase<Product>
    {
        Task<List<GetAllProductsResponse>> GetAllAsync(bool trackChanges, ProductsFilterRequest request);
        Task<Product> GetByIdAsync(Guid id, bool trackChanges);
        Task<List<Product>> GetProductByCategory(Guid id);
    }
}
