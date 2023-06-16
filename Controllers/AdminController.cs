using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UniqueTodoApplication.Interface.IService;
using UniqueTodoApplication.Models;

namespace UniqueTodoApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AdminRequestModel model)
        {
            var admin = await _adminService.RegisterAdmin(model);
            return Ok(admin);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var admin = await _adminService.GetAdmin(id);
            return Ok(admin);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var admin = await _adminService.GetAllAdmin();
            return Ok(admin);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var admin = await _adminService.DeleteAdmin(id);
            return Ok(admin);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAdminRequestModel model)
        {
            var admin = await _adminService.UpdateAdmin(id, model);
            return Ok(admin);
        }
    }
}
