using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniqueTodoApplication.Interface.IService;
using UniqueTodoApplication.Models;

namespace UniqueTodoApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CategoryRequestModel model)
        {
            var category = await _categoryService.RegisterCategory(model);
            return Ok(category);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var category = await _categoryService.GetCategory(id);
            return Ok(category);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var category = await _categoryService.GetAllCategory();
            return Ok(category);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var category = await _categoryService.DeleteCategory(id);
            return Ok(category);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryRequestModel model)
        {
            var category = await _categoryService.UpdateCategory(id, model);
            return Ok(category);
        }
    }
}
