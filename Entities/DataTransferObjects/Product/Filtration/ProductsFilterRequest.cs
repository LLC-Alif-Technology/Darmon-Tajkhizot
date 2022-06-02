using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Product.Filtration
{
    public class ProductsFilterRequest
    {
        public int? Sort { get; set; }
        public string Query { get; set; }
        public Guid? CategoryId { get; set; }
        public double? MinPrice { get; set; }
        public double? MaxPrice { get; set; }
    }
}
