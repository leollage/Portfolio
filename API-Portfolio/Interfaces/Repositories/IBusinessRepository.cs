using API_Portfolio.Model;

namespace API_Portfolio.Interfaces.Repositories
{
    public interface IBusinessRepository
    {
        Task<IEnumerable<Product>> GetProdutosByClienteIdAsync(string clienteId);
        Task<int> InsertAsync(string clientId, string productId);
        Task<int> DeleteAsync(string idClient, string idProduct);
    }
}
