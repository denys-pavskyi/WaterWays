using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WaterWays.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        // GET: api/<ProductController>
        [HttpGet]
        [Route("products")]
        public async Task<ActionResult<IEnumerable<ProductModel>>> Get()
        {
            var Products = await _service.GetAllAsync();

            if (Products == null)
            {
                return NotFound();
            }
            else
            {

                return new ObjectResult(Products);
            }

        }

        // GET api/<ProductController>/5
        [HttpGet("product/{id}")]
        public async Task<ActionResult<ProductModel>> GetById(int id)
        {
            var Product = await _service.GetByIdAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(Product);
            }
        }



        // POST api/ProductPhoto
        [HttpPost("product")]
        public async Task<ActionResult> Post([FromBody] ProductModel Product)
        {
            if (Product == null)
            {
                return BadRequest();
            }
            try
            {
                await _service.AddAsync(Product);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(Product);

        }

        // PUT api/<ProductController>/5
        [HttpPut("product/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductModel value)
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

        // DELETE api/<ProductController>/5
        [HttpDelete("product/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Product = await _service.GetByIdAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return Ok(Product);
        }
    }
}
