using API_Portfolio.Interfaces.Repositories;
using API_Portfolio.Interfaces.Services;
using API_Portfolio.Model;
using AutoMapper;

namespace API_Portfolio.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly IClientService _clientService;
        private readonly IBusinessRepository _businessRepository;
        public BusinessService(IClientService clientService, IBusinessRepository businessRepository)
        {
            _clientService = clientService;
            _businessRepository = businessRepository;
        }
        public async Task<IEnumerable<Product>> GetInvestimentos(string idClient)
        {
            var client = await _businessRepository.GetProdutosByClienteIdAsync(idClient);

            return client;
        }
        public async Task Comprar(string idClient, string idProduct)
        {
            var client = await _clientService.GetByIdAsync(idClient);

            if (client is not null)
            {
                await _businessRepository.InsertAsync(idClient, idProduct);
            }
        }
        public async Task Vender(string idClient, string emailComprador, string idProduct)
        {

            var client = await _clientService.GetByIdAsync(idClient);

            if (emailComprador is not null)
            {
                var comprador = await _clientService.GetByEmailAsync(emailComprador);
                await _businessRepository.InsertAsync(comprador.Id, idProduct);
            }
            await _businessRepository.DeleteAsync(client.Id, idProduct);
        }
    }
}
