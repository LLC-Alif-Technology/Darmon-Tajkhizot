using Contracts.Repositories;
using Entities.DataContexts;
using Entities.DataTransferObjects.Errors;
using Entities.DataTransferObjects.Product;
using Entities.DataTransferObjects.Product.Filtration;
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
    public class EfProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly DataContext _context;
        public EfProductRepository(DataContext context):base(context)
        {
            _context = context;
        }
        public async Task<List<GetAllProductsResponse>> GetAllAsync(bool trackChanges, ProductsFilterRequest request)
        {
            var products = FindAll(trackChanges).Where(x => string.IsNullOrWhiteSpace(request.Query) || x.Name.Contains(request.Query));

            if (request.Sort == 1)
                products.OrderBy(x => x.Price);
            else if (request.Sort == 2)
                products.OrderBy(x => x.Name);
            else if (request.Sort == 3)
                products.OrderByDescending(x => x.Name);
            return await products.Select(x => new GetAllProductsResponse()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Discount = x.Discount,
                Description = x.Description,
                Quantity = x.Quantity,
                VendorCode = x.VendorCode,
                ImagePath = x.ImagePath
                //ImagePath = x.ProductImages.Select(productImage => productImage.ImagePath).FirstOrDefault()
            }).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id, bool trackChanges) => await FindByCondition(x => x.Id.Equals(id), trackChanges).FirstOrDefaultAsync();

        public async Task<List<Product>> GetProductByCategory(Guid id) => await _context.Products.Where(x => x.CategoryId == id).ToListAsync();

    }
}
