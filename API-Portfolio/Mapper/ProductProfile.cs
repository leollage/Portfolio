using API_Portfolio.DTO;
using API_Portfolio.Model;
using AutoMapper;

namespace API_Portfolio.Mapper
{
    public class ProductProfile : Profile   
    {
        public ProductProfile()
        {
            CreateMap<ProductRequestDTO, Product>().ReverseMap();
        }
    }
}
