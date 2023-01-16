using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WaterWays.Controllers
{
    [Route("api/")]
    [ApiController]
    public class VerificationDocumentController : ControllerBase
    {
        private readonly IVerificationDocumentService _service;

        public VerificationDocumentController(IVerificationDocumentService service)
        {
            _service = service;
        }

        // GET: api/<VerificationDocumentController>
        [HttpGet]
        [Route("verificationDocuments")]
        public async Task<ActionResult<IEnumerable<VerificationDocumentModel>>> Get()
        {
            var VerificationDocuments = await _service.GetAllAsync();

            if (VerificationDocuments == null)
            {
                return NotFound();
            }
            else
            {

                return new ObjectResult(VerificationDocuments);
            }

        }

        // GET api/<VerificationDocumentController>/5
        [HttpGet("verificationDocument/{id}")]
        public async Task<ActionResult<VerificationDocumentModel>> GetById(int id)
        {
            var VerificationDocument = await _service.GetByIdAsync(id);
            if (VerificationDocument == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(VerificationDocument);
            }
        }



        // POST api/VerificationDocumentPhoto
        [HttpPost("verificationDocument")]
        public async Task<ActionResult> Post([FromBody] VerificationDocumentModel VerificationDocument)
        {
            if (VerificationDocument == null)
            {
                return BadRequest();
            }
            try
            {
                await _service.AddAsync(VerificationDocument);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(VerificationDocument);

        }

        // PUT api/<VerificationDocumentController>/5
        [HttpPut("verificationDocument/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] VerificationDocumentModel value)
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

        // DELETE api/<VerificationDocumentController>/5
        [HttpDelete("verificationDocument/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var VerificationDocument = await _service.GetByIdAsync(id);
            if (VerificationDocument == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return Ok(VerificationDocument);
        }
    }
}
