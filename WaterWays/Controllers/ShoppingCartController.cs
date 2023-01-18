using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
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
            var shoppingCarts = await _service.GetAllAsync();

            if (shoppingCarts == null)
            {
                return NotFound();
            }
            else
            {

                return new ObjectResult(shoppingCarts);
            }

        }

        // GET: api/<ShoppingCartController>/user/{userId}
        [HttpGet]
        [Route("shoppingCarts/user/{userId}")]
        public async Task<ActionResult<IEnumerable<ShoppingCartModel>>> GetByUserId(int userId)
        {
            var shoppingCarts = await _service.GetAllByUserId(userId);

            if (shoppingCarts == null)
            {
                return NotFound();
            }
            else
            {

                return new ObjectResult(shoppingCarts);
            }

        }

        // GET api/<ShoppingCartController>/5
        [HttpGet("shoppingCart/{id}")]
        public async Task<ActionResult<ShoppingCartModel>> GetById(int id)
        {
            var shoppingCart = await _service.GetByIdAsync(id);
            if (shoppingCart == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(shoppingCart);
            }
        }



        // POST api/ShoppingCartPhoto
        [HttpPost("shoppingCart")]
        public async Task<ActionResult> Post([FromBody] ShoppingCartModel shoppingCart)
        {
            if (shoppingCart == null)
            {
                return BadRequest();
            }
            try
            {
                await _service.AddAsync(shoppingCart);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(shoppingCart);

        }

        // PUT api/<ShoppingCartController>/5
        [HttpPut("shoppingCart")]
        public async Task<ActionResult> Put([FromBody] ShoppingCartModel value)
        {

            try
            {
                int cart_id = await _service.FindByProductAndUserId(value.ProductId, value.UserId);
                

                if (cart_id < 0)
                {
                    await _service.AddAsync(value);
                    return Ok(value);
                }
                else
                {
                    value.Id = cart_id;
                    await _service.UpdateAsync(value);
                }  
            }
            catch
            {
                return BadRequest();
            }


            if (await _service.GetByIdAsync(value.Id) == null)
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
