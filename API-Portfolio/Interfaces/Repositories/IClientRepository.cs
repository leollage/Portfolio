using API_Portfolio.Model;

namespace API_Portfolio.Interfaces.Repositories
{
    public interface IClientRepository
    {
        Task<Client> GetByIdAsync(string id);
        Task<Client> GetByEmailAsync(string email);
        Task<Client> GetByEmailAndPasswordAsync(string email, string password);
        Task<int> InsertAsync(Client client);
        Task<int> UpdateAsync(string id, Client client);
        Task<int> DeleteAsync(string id);

    }
}
