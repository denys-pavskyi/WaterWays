using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WaterWays.Controllers
{
    [Route("api/")]
    [ApiController]
    public class WaterPointController : ControllerBase
    {
        private readonly IWaterPointService _service;

        public WaterPointController(IWaterPointService service)
        {
            _service = service;
        }

        // GET: api/<WaterPointController>
        [HttpGet]
        [Route("waterPoints")]
        public async Task<ActionResult<IEnumerable<WaterPointModel>>> Get()
        {
            var WaterPoints = await _service.GetAllAsync();

            if (WaterPoints == null)
            {
                return NotFound();
            }
            else
            {

                return new ObjectResult(WaterPoints);
            }

        }

        // GET api/<WaterPointController>/5
        [HttpGet("waterPoint/{id}")]
        public async Task<ActionResult<WaterPointModel>> GetById(int id)
        {
            var WaterPoint = await _service.GetByIdAsync(id);
            if (WaterPoint == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(WaterPoint);
            }
        }



        // POST api/WaterPointPhoto
        [HttpPost("waterPoint")]
        public async Task<ActionResult> Post([FromBody] WaterPointModel WaterPoint)
        {
            if (WaterPoint == null)
            {
                return BadRequest();
            }
            try
            {
                await _service.AddAsync(WaterPoint);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(WaterPoint);

        }

        // PUT api/<WaterPointController>/5
        [HttpPut("waterPoint/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] WaterPointModel value)
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

        // DELETE api/<WaterPointController>/5
        [HttpDelete("waterPoint/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var WaterPoint = await _service.GetByIdAsync(id);
            if (WaterPoint == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return Ok(WaterPoint);
        }
    }
}
