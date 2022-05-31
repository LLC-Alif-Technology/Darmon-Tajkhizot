using Entities.DataTransferObjects.Product;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
    public interface IProductRepository:IRepositoryBase<Product>
    {
        Task<List<GetAllProductsResponse>> GetAllAsync(bool trackChanges, string searchString);
        Task<Product> GetByIdAsync(Guid id, bool trackChanges);
    }
}
