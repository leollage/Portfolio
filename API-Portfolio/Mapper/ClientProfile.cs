using API_Portfolio.Model;
using AutoMapper;

namespace API_Portfolio.Mapper
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientRequestDTO, Client>().ReverseMap();

        }
    }
}
