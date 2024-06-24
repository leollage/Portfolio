using API_Portfolio.Interfaces.Services;
using API_Portfolio.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_Portfolio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly ILogger<BusinessController> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IBusinessService _businessService;
        public BusinessController(ILogger<BusinessController> logger,
                                  IAuthorizationService authorizationService,
                                  IBusinessService businessService)
        {
            _logger = logger;
            _authorizationService = authorizationService;
            _businessService = businessService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInvestimentos(LoginDTO login)
        {
            try
            {
                var authorizarion = await _authorizationService.ValidarLogin(login);

                if (authorizarion is null)
                    return BadRequest();

                var produtos = _businessService.GetInvestimentos(authorizarion);
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possivel comprar o produto de investimento! ", ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Comprar/{produtoId}")]
        public async Task<IActionResult> Comprar(LoginDTO login, string produtoId)
        {
            try
            {
                var authorizarion = await _authorizationService.ValidarLogin(login);

                if (authorizarion is null)
                    return BadRequest();

                await _businessService.Comprar(authorizarion, produtoId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possivel comprar o produto de investimento! ", ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Vender/{produtoId}")]
        public async Task<IActionResult> Vender(LoginDTO login, string produtoId, string emailComprador)
        {
            try
            {
                var authorizarion = await _authorizationService.ValidarLogin(login);

                if (authorizarion is null)
                    return BadRequest();

                await _businessService.Vender(authorizarion, emailComprador, produtoId);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Não foi possivel vender o produto de investimento! ", ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
