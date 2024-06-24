using API_Portfolio.DTO;
using API_Portfolio.Interfaces.Services;
using API_Portfolio.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_Portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientService _service;

        public ClientController(ILogger<ClientController> logger, IClientService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var client = await _service.GetByIdAsync(id);

                if (client is null)
                    return NotFound();

                return Ok(client);
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possivel buscar o cliente!", ex);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(ClientRequestDTO client)
        {
            try
            {
                var checkIfClientExistes = await _service.GetByEmailAsync(client.Email);

                if (checkIfClientExistes is not null)
                    return BadRequest("Já existe um cliente com esse e-mail cadastrado! ");

                await _service.CreateAsync(client);
                return Ok(client);
            }
            catch(Exception ex)
            {
                _logger.LogError("Não foi possivel cadastrar o cliente!", ex);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, ClientRequestDTO client)
        {
            try
            {
                var checkIfClientExistes = await _service.GetByIdAsync(id);

                if (checkIfClientExistes is null)
                    return NotFound();

                await _service.UpdateAsync(id, client);

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
                var checkIfClientExistes = await _service.GetByIdAsync(id);

                if (checkIfClientExistes is null)
                    return NotFound();

                await _service.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
