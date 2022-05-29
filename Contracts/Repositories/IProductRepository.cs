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
        Task<List<GetAllProductsResponse>> GetAllAsync(bool trackChanges);
        Task<Product> GetByIdAsync(Guid id, bool trackChanges);
    }
}
