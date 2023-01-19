using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WaterWays.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        // GET: api/<OrderController>
        [HttpGet]
        [Route("orders")]
        public async Task<ActionResult<IEnumerable<OrderModel>>> Get()
        {
            var Orders = await _service.GetAllAsync();

            if (Orders == null)
            {
                return NotFound();
            }
            else
            {

                return new ObjectResult(Orders);
            }

        }

        // GET: api/<OrderController>/user/{userId}
        [HttpGet]
        [Route("orders/user/{userId}")]
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetByUserId(int userId)
        {
            var Orders = await _service.GetAllByUserId(userId);

            if (Orders == null)
            {
                return NotFound();
            }
            else
            {

                return new ObjectResult(Orders);
            }

        }


        // GET api/<OrderController>/5
        [HttpGet("order/{id}")]
        public async Task<ActionResult<OrderModel>> GetById(int id)
        {
            var Order = await _service.GetByIdAsync(id);
            if (Order == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(Order);
            }
        }



        // POST api/OrderPhoto
        [HttpPost("order")]
        public async Task<ActionResult> Post([FromBody] OrderModel Order)
        {
            int newId = 0;
            if (Order == null)
            {
                return BadRequest();
            }
            try
            {
                newId = await _service.AddAsyncReturnId(Order);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(newId);

        }

        // PUT api/<OrderController>/5
        [HttpPut("order/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] OrderModel value)
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

        // DELETE api/<OrderController>/5
        [HttpDelete("order/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Order = await _service.GetByIdAsync(id);
            if (Order == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return Ok(Order);
        }
    }
}
