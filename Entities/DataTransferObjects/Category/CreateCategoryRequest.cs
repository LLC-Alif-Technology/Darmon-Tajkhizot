using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Category
{
    public class CreateCategoryRequest
    {
        [Required]
        public string Name { get; set; }
        public bool? IsPopular { get; set; }
        public IFormFile Icon { get; set; }
        public IFormFile Image { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}
