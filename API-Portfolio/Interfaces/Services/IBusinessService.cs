using API_Portfolio.Model;

namespace API_Portfolio.Interfaces.Services
{
    public interface IBusinessService
    {
        Task<IEnumerable<Product>> GetInvestimentos(string idClient);
        Task Comprar(string idClient, string idProduct);
        Task Vender(string idClient, string emailComprador, string idProduct);
    }
}
