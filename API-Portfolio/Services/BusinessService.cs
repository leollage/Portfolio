using API_Portfolio.Interfaces.Services;
using API_Portfolio.Model;
using AutoMapper;

namespace API_Portfolio.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly IClientService _clientService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public BusinessService(IClientService clientService, IProductService productService, IMapper mapper)
        {
            _clientService = clientService;
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<List<Product>> GetInvestimentos(string idClient)
        {
            var client = await _clientService.GetByIdAsync(idClient);

            return client.Products.ToList();
        }
        public async Task Comprar(string idClient, string idProduct)
        {
            var client = await _clientService.GetByIdAsync(idClient);
            var product = await _productService.GetByIdAsync(idProduct);
            client!.Products.Add(product!);

            ClientRequestDTO clientDto = _mapper.Map<ClientRequestDTO>(client);

            await _clientService.UpdateAsync(client.Id, clientDto);
        }
        public async Task Vender(string idClient, string emailComprador, string idProduct)
        {
            var client = await _clientService.GetByIdAsync(idClient);
            var product = await _productService.GetByIdAsync(idProduct);
            client!.Products.Remove(client.Products.Single(p => p.Id == product!.Id));
            ClientRequestDTO clientDto = _mapper.Map<ClientRequestDTO>(client);

            if (emailComprador is not null)
            {
                var comprador = await _clientService.GetByEmailAsync(emailComprador);
                comprador!.Products.Add(product!);
                ClientRequestDTO compradorDto = _mapper.Map<ClientRequestDTO>(comprador);
                await _clientService.UpdateAsync(comprador.Id, compradorDto);


            }
            await _clientService.UpdateAsync(client.Id, clientDto);
        }
    }
}
