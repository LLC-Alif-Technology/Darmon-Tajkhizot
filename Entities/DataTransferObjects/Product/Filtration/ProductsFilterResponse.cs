using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Product.Filtration
{
    public class ProductsFilterResponse
    {
        public double MaxPrice { get; set; }
        public double MinPrice { get; set; }
        public List<FiltersResponse> Filters { get; set; }
    }
}
