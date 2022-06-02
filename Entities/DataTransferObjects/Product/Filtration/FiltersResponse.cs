using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Product.Filtration
{
    public class FiltersResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<FilterValuesResponse> Values { get; set; }
    }
}
