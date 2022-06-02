using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Product.Filtration
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public double? Discount { get; set; }
        public double Price { get; set; }
        public string VendorCode { get; set; }
    }
}
