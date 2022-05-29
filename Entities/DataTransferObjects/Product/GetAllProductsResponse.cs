using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Product
{
    public class GetAllProductsResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double? Discount { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string VendorCode { get; set; }
    }
}
