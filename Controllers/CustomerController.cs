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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerRequestModel model)
        {
            var customer = await _customerService.RegisterCustomer(model);
            return Ok(customer);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var customer = await _customerService.GetCustomer(id);
            return Ok(customer);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var customer = await _customerService.GetAllCustomer();
            return Ok(customer);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var customer = await _customerService.DeleteCustomer(id);
            return Ok(customer);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCustomerRequestModel model)
        {
            var customer = await _customerService.UpdateCustomer(id, model);
            return Ok(customer);
        }
    }
}
