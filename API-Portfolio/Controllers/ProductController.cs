using API_Portfolio.DTO;
using API_Portfolio.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace API_Portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _service;

        public ProductController(ILogger<ProductController> logger, IProductService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var investmentProducts = await _service.GetAsync();

                if (investmentProducts is null)
                    return NotFound();

                return Ok(investmentProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possivel buscar os produtos de investimento!", ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var investmentProducts = await _service.GetByIdAsync(id);

                if (investmentProducts is null)
                    return NotFound();

                return Ok(investmentProducts);

            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possivel buscar o produto de investimento!", ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductRequestDTO product)
        {
            try
            {
                var checkIfProductsExistes = await _service.GetByNameAsync(product.Name);

                if (checkIfProductsExistes is not null)
                    return BadRequest("Já existe um produto com esse nome cadastrado! ");

                await _service.CreateAsync(product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, ProductRequestDTO product)
        {
            try
            {
                var checkIfProductsExistes = await _service.GetByIdAsync(id);

                if (checkIfProductsExistes is null)
                    return NotFound();

                await _service.UpdateAsync(id, product);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                var checkIfProductsExistes = await _service.GetByIdAsync(id);

                if (checkIfProductsExistes is null)
                    return NotFound();

                await _service.RemoveAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}