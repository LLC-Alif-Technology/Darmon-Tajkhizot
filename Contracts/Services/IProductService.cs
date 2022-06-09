using Entities.DataTransferObjects.Product;
using Entities.DataTransferObjects.Product.Filtration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IProductService
    {
        Task<List<GetAllProductsResponse>> GetAllAsync(ProductsFilterRequest request, int? pageNumber, int pagesize);
        //Task<List<GetAllProductsResponse>> GetAllAsync();
        Task<Guid> CreateAsync(CreateProductRequest request);
        Task DeleteProductAsync(Guid productId);
    }
}
