using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Product
{
    public class UpdateProductRequest
    {
        public string Name { get; set; }
        public double? Price { get; set; }
        public double? Discount { get; set; }
        public string Description { get; set; }
        public Guid? CategoryId { get; set;}
        public int? Quantity { get; set; }
        public string VendorCode { get; set; }
        public IFormFile Image { get; set; }
    }
}
