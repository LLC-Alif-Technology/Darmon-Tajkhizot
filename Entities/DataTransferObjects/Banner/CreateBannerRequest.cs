using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects.Banner
{
    public class CreateBannerRequest
    {
        [Required]
        public IFormFile Image { get; set; }

        [Required]
        public string Href { get; set; }
    }
}
