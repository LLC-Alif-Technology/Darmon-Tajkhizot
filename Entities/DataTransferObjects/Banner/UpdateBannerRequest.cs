using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Banner
{
    public class UpdateBannerRequest
    {
        public IFormFile Image { get; set; }
        public string Href { get; set; }
    }
}
