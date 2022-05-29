using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double? Discount { get; set; }
        public string Description { get; set; }
        public string VendorCode { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime CreateAt { get; set; }
        public virtual Category Category { get; set; }
        public virtual IEnumerable<ProductImage> ProductImages { get; set; }
    }
}
