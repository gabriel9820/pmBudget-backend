using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pmBudget.Application.Common;
using pmBudget.Application.DTOs.InputModels;
using pmBudget.Application.DTOs.OutputModels;
using pmBudget.Application.Interfaces;

namespace pmBudget.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesApplicationService _categoriesApplicationService;
        private readonly ILoggedInUserService _loggedInUserService;

        public CategoriesController(ICategoriesApplicationService categoriesApplicationService, ILoggedInUserService loggedInUserService)
        {
            _categoriesApplicationService = categoriesApplicationService;
            _loggedInUserService = loggedInUserService;
        }

        [HttpGet]
        public async Task<IActionResult> FindAsync()
        {
            var categories = await _categoriesApplicationService.FindAsync(t => t.UserId == _loggedInUserService.Id);
            var response = Response<IEnumerable<CategoryOutputModel>>.Ok(data: categories);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var category = await _categoriesApplicationService.GetByIdAsync(id);
            var response = Response<CategoryOutputModel>.Ok(data: category);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CategoryInputModel categoryInputModel)
        {
            var createdCategory = await _categoriesApplicationService.CreateAsync(categoryInputModel);
            var response = Response<CategoryOutputModel>.Ok(data: createdCategory);

            return Created("", response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] CategoryInputModel categoryInputModel)
        {
            var updatedCategory = await _categoriesApplicationService.UpdateAsync(id, categoryInputModel);
            var response = Response<CategoryOutputModel>.Ok(data: updatedCategory);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _categoriesApplicationService.DeleteAsync(id);

            return NoContent();
        }
    }
}