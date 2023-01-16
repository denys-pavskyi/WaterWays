using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WaterWays.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _service;

        public OrderDetailController(IOrderDetailService service)
        {
            _service = service;
        }

        // GET: api/<OrderDetailController>
        [HttpGet]
        [Route("orderDetails")]
        public async Task<ActionResult<IEnumerable<OrderDetailModel>>> Get()
        {
            var OrderDetails = await _service.GetAllAsync();

            if (OrderDetails == null)
            {
                return NotFound();
            }
            else
            {

                return new ObjectResult(OrderDetails);
            }

        }

        // GET api/<OrderDetailController>/5
        [HttpGet("orderDetail/{id}")]
        public async Task<ActionResult<OrderDetailModel>> GetById(int id)
        {
            var OrderDetail = await _service.GetByIdAsync(id);
            if (OrderDetail == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(OrderDetail);
            }
        }



        // POST api/OrderDetailPhoto
        [HttpPost("orderDetail")]
        public async Task<ActionResult> Post([FromBody] OrderDetailModel OrderDetail)
        {
            if (OrderDetail == null)
            {
                return BadRequest();
            }
            try
            {
                await _service.AddAsync(OrderDetail);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(OrderDetail);

        }

        // PUT api/<OrderDetailController>/5
        [HttpPut("orderDetail/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] OrderDetailModel value)
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

        // DELETE api/<OrderDetailController>/5
        [HttpDelete("orderDetail/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var OrderDetail = await _service.GetByIdAsync(id);
            if (OrderDetail == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return Ok(OrderDetail);
        }
    }
}
