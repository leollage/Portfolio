using API_Portfolio.DTO;
using API_Portfolio.Interfaces.Repositories;
using API_Portfolio.Interfaces.Services;
using API_Portfolio.Model;
using AutoMapper;

namespace API_Portfolio.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository; 
            _mapper = mapper;
        }
        public async Task<List<Product>> GetAsync() => await _repository.GetAsync();
        public async Task<Product?> GetByIdAsync(string id) => await _repository.GetByIdAsync(id);
        public async Task<Product?> GetByNameAsync(string name) => await _repository.GetByNameAsync(name);
        public async Task CreateAsync(ProductRequestDTO newProduct)
        {
            Product product = _mapper.Map<Product>(newProduct);

            await _repository.InsertAsync(product);
        }
        public async Task UpdateAsync(string id, ProductRequestDTO updatedProduct)
        {
            Product product = _mapper.Map<Product>(updatedProduct);
            product.Id = id;

            await _repository.UpdateAsync(id, product);
        }
        public async Task RemoveAsync(string id) => await _repository.DeleteAsync(id);

    }
}
