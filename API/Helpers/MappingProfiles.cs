using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDTO>()
            .ForMember(dest => dest.ProductBrand, o => o.MapFrom(source => source.ProductBrand.Name))
            .ForMember(dest => dest.ProductType, o => o.MapFrom(source => source.ProductType.Name))
            .ForMember(dest => dest.PictureUrl, o => o.MapFrom<UrlResolver>());
        }
    }
}