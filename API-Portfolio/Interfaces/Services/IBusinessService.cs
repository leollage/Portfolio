using API_Portfolio.Model;

namespace API_Portfolio.Interfaces.Services
{
    public interface IBusinessService
    {
        Task<List<Product>> GetInvestimentos(string idClient);
        Task Comprar(string idClient, string idProduct);
        Task Vender(string idClient, string emailComprador, string idProduct);
    }
}
