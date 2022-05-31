using Contracts.Services;
using Entities.DataTransferObjects.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Darmon_Tajkhizot.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllAsync()
        //{
        //    return Ok(await _productService.GetAllAsync());
        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductRequest request)
        {
            return Created("products", await _productService.CreateAsync(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string searchString, int? pageindex, int pagesize)
        {
            return Ok(await _productService.GetAllAsync(searchString, pageindex, pagesize));
        }

    }
}
