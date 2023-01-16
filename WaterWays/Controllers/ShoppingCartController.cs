using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WaterWays.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _service;

        public ShoppingCartController(IShoppingCartService service)
        {
            _service = service;
        }

        // GET: api/<ShoppingCartController>
        [HttpGet]
        [Route("shoppingCarts")]
        public async Task<ActionResult<IEnumerable<ShoppingCartModel>>> Get()
        {
            var ShoppingCarts = await _service.GetAllAsync();

            if (ShoppingCarts == null)
            {
                return NotFound();
            }
            else
            {

                return new ObjectResult(ShoppingCarts);
            }

        }

        // GET api/<ShoppingCartController>/5
        [HttpGet("shoppingCart/{id}")]
        public async Task<ActionResult<ShoppingCartModel>> GetById(int id)
        {
            var ShoppingCart = await _service.GetByIdAsync(id);
            if (ShoppingCart == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(ShoppingCart);
            }
        }



        // POST api/ShoppingCartPhoto
        [HttpPost("shoppingCart")]
        public async Task<ActionResult> Post([FromBody] ShoppingCartModel ShoppingCart)
        {
            if (ShoppingCart == null)
            {
                return BadRequest();
            }
            try
            {
                await _service.AddAsync(ShoppingCart);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(ShoppingCart);

        }

        // PUT api/<ShoppingCartController>/5
        [HttpPut("shoppingCart/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ShoppingCartModel value)
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

        // DELETE api/<ShoppingCartController>/5
        [HttpDelete("shoppingCart/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ShoppingCart = await _service.GetByIdAsync(id);
            if (ShoppingCart == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return Ok(ShoppingCart);
        }
    }
}
