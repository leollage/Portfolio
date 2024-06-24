using API_Portfolio.Model;

namespace API_Portfolio.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAsync();
        Task<Product> GetByIdAsync(string id);
        Task<Product> GetByNameAsync(string name);
        Task<int> InsertAsync(Product product);
        Task<int> UpdateAsync(string id, Product product);
        Task<int> DeleteAsync(string id);
    }
}
