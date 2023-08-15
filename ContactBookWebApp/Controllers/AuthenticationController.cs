using ContactBookWebApp.Application.Services.Interfaces;
using ContactBookWebApp.Domain.Dto.UserDto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactBookWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        // GET: api/<AuthenticationController>
  /*    [HttpGet]     
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthenticationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<AuthenticationController>
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRequestDto requestDto)
        {
            var result = await _authenticationService.RegisterUser(requestDto);
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginDto requestDto)
        {
            if(!await _authenticationService.ValidateUser(requestDto))
            {
                return Unauthorized();
            }

            return Ok(new {token = await _authenticationService.CreateToken()});
        }

        /*     // PUT api/<AuthenticationController>/5
             [HttpPut("{id}")]
             public void Put(int id, [FromBody] string value)
             {
             }

             // DELETE api/<AuthenticationController>/5
             [HttpDelete("{id}")]
             public void Delete(int id)
             {
             }*/
    }
}
