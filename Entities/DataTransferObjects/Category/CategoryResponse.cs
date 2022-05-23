using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Category
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<CategoryResponse> SubCategories { get; set; }
    }
}
