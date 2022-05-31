using Entities.DataTransferObjects.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IProductService
    {
        //Task<List<GetAllProductsResponse>> GetAllAsync(int? pageNumber);
        Task<List<GetAllProductsResponse>> GetAllAsync();
        Task<Guid> CreateAsync(CreateProductRequest request);
    }
}
