using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Banner
{
    public class BannerResponse
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public string Href { get; set; }
    }
}
