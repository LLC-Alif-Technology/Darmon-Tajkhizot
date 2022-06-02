using Contracts.Repositories;
using Entities.DataContexts;
using Entities.DataTransferObjects.Errors;
using Entities.DataTransferObjects.Product;
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
        public async Task<List<GetAllProductsResponse>> GetAllAsync(bool trackChanges, string searchString) => await FindAll(trackChanges).Where(x => string.IsNullOrWhiteSpace(searchString) || x.Name.Contains(searchString)).Select(x => new GetAllProductsResponse()
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


        public async Task<Product> GetByIdAsync(Guid id, bool trackChanges) => await FindByCondition(x => x.Id.Equals(id), trackChanges).FirstOrDefaultAsync();

        public async Task<List<Product>> GetProductByCategory(Guid id) => await _context.Products.Where(x => x.CategoryId == id).ToListAsync();

    }
}
