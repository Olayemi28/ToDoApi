using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UniqueTodoApplication.Interface.IService;
using UniqueTodoApplication.Models;

namespace UniqueTodoApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoitemController : ControllerBase
    {
        private readonly ITodoitemService _todoitemService;
        public TodoitemController(ITodoitemService todoitemService)
        {
            _todoitemService = todoitemService;
        }

        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] TodoitemRequestModel model)
        {
            var signedInUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var todoitem = await _todoitemService.RegisterTodoitem(model, signedInUserId);
            return Ok(todoitem);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var todoitem = await _todoitemService.GetTodoitem(id);
            return Ok(todoitem);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var todoitem = await _todoitemService.GetAllTodoitem();
            return Ok(todoitem);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var todoitem = await _todoitemService.DeleteTodoitem(id);
            return Ok(todoitem);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTodoitemRequestModel model)
        {
            var todoitem = await _todoitemService.UpdateTodoitem(id, model);
            return Ok(todoitem);
        }
    }
}
