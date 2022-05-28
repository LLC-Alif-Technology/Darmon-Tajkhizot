using Contracts.Services;
using Entities.DataTransferObjects.Banner;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Darmon_Tajkhizot.Controllers
{
    public class BannerController : BaseController
    {
        private readonly IBannerService _bannerService;
        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBannerRequest request)
        {
            return Created("banners", await _bannerService.CreateAsync(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _bannerService.GetAllAsync());
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedBannerId = await _bannerService.DeleteByIdAsync(id);
            if (deletedBannerId == Guid.Empty)
                return NotFound();
            return Ok(deletedBannerId);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateBannerRequest request)
        {
            await _bannerService.UpdateAsync(id,request);
            return NoContent();
        }
    } 
}


