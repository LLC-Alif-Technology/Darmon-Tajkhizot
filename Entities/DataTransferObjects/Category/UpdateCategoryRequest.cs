using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Category
{
    public class UpdateCategoryRequest
    {
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public bool? IsPopular { get; set; } = false;
        public IFormFile Image { get; set; }
        public IFormFile Icon { get; set; }
    }
}
