using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WaterWays.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _service;

        public ReviewController(IReviewService service)
        {
            _service = service;
        }

        // GET: api/<ReviewController>
        [HttpGet]
        [Route("reviews")]
        public async Task<ActionResult<IEnumerable<ReviewModel>>> Get()
        {
            var Reviews = await _service.GetAllAsync();

            if (Reviews == null)
            {
                return NotFound();
            }
            else
            {

                return new ObjectResult(Reviews);
            }

        }

        // GET api/<ReviewController>/5
        [HttpGet("review/{id}")]
        public async Task<ActionResult<ReviewModel>> GetById(int id)
        {
            var Review = await _service.GetByIdAsync(id);
            if (Review == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(Review);
            }
        }



        // POST api/ReviewPhoto
        [HttpPost("review")]
        public async Task<ActionResult> Post([FromBody] ReviewModel Review)
        {
            if (Review == null)
            {
                return BadRequest();
            }
            try
            {
                await _service.AddAsync(Review);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(Review);

        }

        // PUT api/<ReviewController>/5
        [HttpPut("review/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ReviewModel value)
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

        // DELETE api/<ReviewController>/5
        [HttpDelete("review/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Review = await _service.GetByIdAsync(id);
            if (Review == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return Ok(Review);
        }
    }
}
