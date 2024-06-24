using API_Portfolio.Interfaces.Services;
using API_Portfolio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace API_Portfolio.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IClientService _clientService;
        public AuthorizationService(IClientService clientService)
        {
            _clientService = clientService;

        }
        public async Task<string> ValidarLogin(LoginDTO login)
        {
            var checkIfClientExistes = await _clientService.GetByEmailAndPasswordAsync(login.Email, login.Password);
            if (checkIfClientExistes == null)
                throw new Exception("Não foi possivel realizar o login! ");
            return checkIfClientExistes.Id;
        }
    }
}
