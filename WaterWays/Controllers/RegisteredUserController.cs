using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WaterWays.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RegisteredUserController : ControllerBase
    {
        private readonly IRegisteredUserService _service;

        public RegisteredUserController(IRegisteredUserService service)
        {
            _service = service;
        }

        // GET: api/<RegisteredUserController>
        [HttpGet]
        [Route("registeredUsers")]
        public async Task<ActionResult<IEnumerable<RegisteredUserModel>>> Get()
        {
            var RegisteredUsers = await _service.GetAllAsync();

            if (RegisteredUsers == null)
            {
                return NotFound();
            }
            else
            {

                return new ObjectResult(RegisteredUsers);
            }

        }

        // GET api/<RegisteredUserController>/5
        [HttpGet("registeredUser/{id}")]
        public async Task<ActionResult<RegisteredUserModel>> GetById(int id)
        {
            var RegisteredUser = await _service.GetByIdAsync(id);
            if (RegisteredUser == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(RegisteredUser);
            }
        }



        // POST api/RegisteredUserPhoto
        [HttpPost("registeredUser")]
        public async Task<ActionResult> Post([FromBody] RegisteredUserModel RegisteredUser)
        {
            if (RegisteredUser == null)
            {
                return BadRequest();
            }
            try
            {
                await _service.AddAsync(RegisteredUser);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(RegisteredUser);

        }

        // PUT api/<RegisteredUserController>/5
        [HttpPut("registeredUser/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RegisteredUserModel value)
        {
            try
            {
                await _service.UpdateAsync(value);
            }
            catch
            {
                return BadRequest();
            }


            if (await _service.GetByIdAsync(id) == null)
            {
                return BadRequest();
            }

            return Ok(value);
        }

        // DELETE api/<RegisteredUserController>/5
        [HttpDelete("registeredUser/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var RegisteredUser = await _service.GetByIdAsync(id);
            if (RegisteredUser == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return Ok(RegisteredUser);
        }
    }
}
