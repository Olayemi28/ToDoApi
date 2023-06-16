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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] RoleRequestModel model)
        {
            var role = await _roleService.RegisterRole(model);
            return Ok(role);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var role = await _roleService.GetRole(id);
            return Ok(role);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var role = await _roleService.GetAllRole();
            return Ok(role);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var role = await _roleService.DeleteRole(id);
            return Ok(role);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRoleRequestModel model)
        {
            var role = await _roleService.UpdateRole(id, model);
            return Ok(role);
        }
    }
}
