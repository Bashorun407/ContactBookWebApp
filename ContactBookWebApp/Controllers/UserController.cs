using ContactBookWebApp.Application.Services.Interfaces;
using ContactBookWebApp.Domain.Dto.UserDto;
using ContactWebApp.Shared.RequestParameter.ModelParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactBookWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        //[Authorize(Roles ="Admin")]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllUsers([FromQuery] UserRequestInputParameter parameter)
        {
            var result = await _userService.GetAllUsers(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.Data.Item2));
            return Ok(result.Data.users);
        }

        // GET api/<UsersController>/5
        //[Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var result = await _userService.GetUserById(id);
            return Ok(result);
        }

        //[Authorize]
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var result = await _userService.GetUserByEmail(email);
            return Ok(result);
        }
        // [Authorize]
        [HttpPost("{id}/image")]
        public IActionResult UploadProfilePic(string id, IFormFile file)
        {
            var result = _userService.UploadProfileImage(id, file);
            if (result.Result.Succeeded)
            {
                return Ok(new { ImageUrl = result.Result.Data.Item2 });
            }
            return NotFound();
        }

        // PUT api/<UsersController>/5
        //[Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserRequestDto requestDto)
        {
            var result = await _userService.UpdateUser(id, requestDto);
            return Ok(result);
        }
    }
}
