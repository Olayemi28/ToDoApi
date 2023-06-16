using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniqueTodoApplication.Interface.IService;
using UniqueTodoApplication.Models;

namespace UniqueTodoApplication.Controllers
{
    public class SubcategoryController : ControllerBase
    {
        private readonly ISubcategoryService _subcategoryService;

        public SubcategoryController(ISubcategoryService subcategoryService)
        {
            _subcategoryService = subcategoryService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] SubcategoryRequestModel model)
        {
            var category = await _subcategoryService.RegisterSubcategory(model);
            return Ok(category);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var category = await _subcategoryService.GetSubcategory(id);
            return Ok(category);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var category = await _subcategoryService.GetAllSubcategory();
            return Ok(category);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var category = await _subcategoryService.DeleteSubcategory(id);
            return Ok(category);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSubcategoryRequestModel model)
        {
            var category = await _subcategoryService.UpdateSubcategory(id, model);
            return Ok(category);
        }
    }
}
