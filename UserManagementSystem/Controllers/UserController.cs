﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementSystem.Models;
using UserManagementSystem.Services;

namespace UserManagementSystem.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsersAsync()
        {
            return await _userService.GetAllUsersAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetSingleUserAsync(int id)
        {
            var result = await _userService.GetSingleUserAsync(id);
            if (result is null)
            {
                return NotFound("Something went wrong");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUserAsync(User user)
        {
            var result = await _userService.CreateUserAsync(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUserAsync(int id, User request)
        {
            var result = await _userService.UpdateUserAsync(id, request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUserAsync(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            return Ok(result);
        }
    }
}
