using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class ProductImage
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ImagePath { get; set; }
        public bool IsMain { get; set; }
        public virtual Product Product { get; set; }
    }
}
