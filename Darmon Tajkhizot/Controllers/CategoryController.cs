using Contracts.Services;
using Entities.DataTransferObjects.Category;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Darmon_Tajkhizot.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService service)
        {
            _categoryService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categoryService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCategoryRequest request)
        {
            return Created("categories", await _categoryService.CreateAsync(request));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromForm] UpdateCategoryRequest request)
        {
            await _categoryService.UpdateAsync(id, request);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedCategoryId = await _categoryService.DeleteByIdAsync(id);
            if (deletedCategoryId == Guid.Empty)
                return NotFound();
            return Ok(deletedCategoryId);
        }

    }
}
