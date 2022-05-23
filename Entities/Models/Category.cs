using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
        public string ImagePath { get; set; }
        public bool IsPopular { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
        public virtual IEnumerable<Category> SubCategories { get; set; }
    }
}
