using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Banner
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public string Href { get; set; }
    }
}
