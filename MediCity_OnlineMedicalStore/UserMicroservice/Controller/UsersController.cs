using MediCity_OnlineMedicalStore.UserMicroservice.BusinessLayer.ModelDto;
using MediCity_OnlineMedicalStore.UserMicroservice.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MediCity_OnlineMedicalStore.UserMicroservice.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public ActionResult<UserDto> GetUserById(int userId)
        {
            var user = _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public ActionResult<UserDto> CreateUser(UserDto userDto)
        {
            var createdUser = _userService.CreateUser(userDto);
            return CreatedAtAction(nameof(GetUserById), new { userId = createdUser.Id }, createdUser);
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser(int userId, UserDto userDto)
        {
            if (userId != userDto.Id)
            {
                return BadRequest();
            }

            var updatedUser = _userService.UpdateUser(userDto);
            if (updatedUser == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            var result = _userService.DeleteUser(userId);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
