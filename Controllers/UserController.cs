using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniqueTodoApplication.Auth;
using UniqueTodoApplication.DTOs;
using UniqueTodoApplication.Interface.IService;
using UniqueTodoApplication.Models;

namespace UniqueTodoApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJWTAuthenticationManager _jWTAuthenticationManager;
        public UserController(IUserService userService, IJWTAuthenticationManager jWTAuthenticationManager)
        {
            _jWTAuthenticationManager = jWTAuthenticationManager;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var user = await _userService.GetUser(id);
            return Ok(user);
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var user = await _userService.GetAllUser();
            return Ok(user);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {

            var response = await _userService.Login(model);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            var token = _jWTAuthenticationManager.GenerateToken(response.Data);
            var user = response.Data;


            var log = new LoginResponseDto
            {
                Message = "User sucessfully logged in",
                Success = true,
                Token = token,
                Data = response.Data

            };
            return Ok(log);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var user = await _userService.DeleteUser(id);
            return Ok(user);
        }
    }
}
