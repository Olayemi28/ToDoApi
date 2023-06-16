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
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ItemRequestModel model)
        {
            var item = await _itemService.RegisterItem(model);
            return Ok(item);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var item = await _itemService.GetItem(id);
            return Ok(item);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var item = await _itemService.GetAllItem();
            return Ok(item);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var item = await _itemService.DeleteItem(id);
            return Ok(item);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateItemRequestModel model)
        {
            var item = await _itemService.UpdateItem(id, model);
            return Ok(item);
        }
    }
}
