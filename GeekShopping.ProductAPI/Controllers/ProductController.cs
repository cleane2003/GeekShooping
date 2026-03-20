using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repository.Interfaces;
using GeekShopping.ProductAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _productRepository.FindAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize]

        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _productRepository.FindById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        [Authorize]

        public async Task<ActionResult<IEnumerable<ProductVO>>> Create([FromBody] ProductVO product)
        {
            if (product == null) return BadRequest();
            var createdProduct = await _productRepository.Create(product);
            return Ok(createdProduct);
        }


        [HttpPut]
        [Authorize]

        public async Task<ActionResult<IEnumerable<ProductVO>>> Update([FromBody] ProductVO product)
        {
            if (product == null) return BadRequest();
            var updateProduct = await _productRepository.Update(product);
            return Ok(updateProduct);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _productRepository.Delete(id);
            if (!status) return NotFound();
            return Ok(status);
        }
    }
}
