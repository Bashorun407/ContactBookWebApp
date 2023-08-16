using ContactBookWebApp.Application.Services.Interfaces;
using ContactBookWebApp.Domain.Dto.ContactDto;
using ContactWebApp.Shared.RequestParameter.ModelParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactBookWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllContacts([FromQuery] ContactRequestInputParameter parameter)
        {
            var result = await _contactService.GetAllContacts(parameter);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(parameter));
            return Ok(result.Data.contacts);
        }

        //[Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var result = await _contactService.GetContactById(id);
            return Ok(result);
        }

        //[Authorize]
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetContactById(string email)
        {
            var result = await _contactService.GetContactByEmail(email);
            return Ok(result);
        }

        // POST api/<UsersController>
        //[Authorize(Roles = "Admin")]
        [HttpPost("contact")]
        public async Task<IActionResult> CreateContact([FromBody] ContactRequestDto requestDto)
        {
            var result = await _contactService.CreateContact(requestDto);
            return Ok(result);
        }

        // PUT api/<UsersController>/5
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] ContactRequestDto requestDto)
        {
            var result = await _contactService.UpdateContact(id, requestDto);
            return Ok(result);
        }

        // DELETE api/<UsersController>/5
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var result = await _contactService.DeleteContact(id);
            return Ok(result);
        }
    }
}
