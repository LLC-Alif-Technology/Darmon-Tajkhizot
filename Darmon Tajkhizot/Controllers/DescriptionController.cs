using Contracts.Services;
using Entities.DataTransferObjects.Description;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Darmon_Tajkhizot.Controllers
{
    public class DescriptionController : BaseController
    {
        private readonly IDescriptionService _descriptionService;
        public DescriptionController(IDescriptionService descriptionService)
        {
            _descriptionService = descriptionService;
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromForm] UpdateDescriptionRequest request)
        {
            await _descriptionService.UpdateAsync(id, request);
            return NoContent();
        }
    }
}
