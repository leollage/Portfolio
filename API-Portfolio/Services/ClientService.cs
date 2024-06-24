using API_Portfolio.DTO;
using API_Portfolio.Interfaces.Repositories;
using API_Portfolio.Interfaces.Services;
using API_Portfolio.Model;
using AutoMapper;

namespace API_Portfolio.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;
        public ClientService(IClientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Client?> GetByIdAsync(string id) => await _repository.GetByIdAsync(id);
        public async Task<Client?> GetByEmailAsync(string email) => await _repository.GetByEmailAsync(email);
        public async Task<Client?> GetByEmailAndPasswordAsync(string email, string password) => await _repository.GetByEmailAndPasswordAsync(email, password);
        public async Task CreateAsync(ClientRequestDTO newClient)
        {
            Client client = _mapper.Map<Client>(newClient);

            await _repository.InsertAsync(client);
        }
        public async Task UpdateAsync(string id, ClientRequestDTO updatedClient)
        {
            Client client = _mapper.Map<Client>(updatedClient);
            client.Id = id;

            await _repository.UpdateAsync(id, client);
        }
        public async Task DeleteAsync(string id) => await _repository.DeleteAsync(id);
    }
}
