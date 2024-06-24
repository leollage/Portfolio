using API_Portfolio.Model;

namespace API_Portfolio.Interfaces.Services
{
    public interface IClientService
    {
        Task<Client?> GetByIdAsync(string id);
        Task<Client?> GetByEmailAsync(string email);
        Task<Client?> GetByEmailAndPasswordAsync(string email, string password);
        Task CreateAsync(ClientRequestDTO newClient);
        Task UpdateAsync(string id, ClientRequestDTO updatedClient);
        Task DeleteAsync(string id);
    }
}
