using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Models;
using ProductMicroservice.Repository;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            var products = await _productRepository.GetProducts();
            return new OkObjectResult(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _productRepository.GetProductById(id);

            if (product != null)
                return new OkObjectResult(product);

            return BadRequest("There is no such a product.");
        }

        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            await _productRepository.InsertProduct(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        // PUT: api/Product
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Product product)
        {
            if (product != null)
            {
                await _productRepository.UpdateProduct(product);
                return Ok();
            }

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productRepository.DeleteProduct(id);
            return Ok();
        }
    }
}
