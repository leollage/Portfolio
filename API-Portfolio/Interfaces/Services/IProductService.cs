using API_Portfolio.DTO;
using API_Portfolio.Model;

namespace API_Portfolio.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAsync();
        Task<Product?> GetByIdAsync(string id);
        Task<Product?> GetByNameAsync(string name);
        Task CreateAsync(ProductRequestDTO newProduct);
        Task UpdateAsync(string id, ProductRequestDTO updatedProduct);
        Task RemoveAsync(string id);
    }
}
