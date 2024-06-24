using API_Portfolio.Model;

namespace API_Portfolio.Interfaces.Services
{
    public interface IAuthorizationService
    {
        Task<string> ValidarLogin(LoginDTO login);
    }
}