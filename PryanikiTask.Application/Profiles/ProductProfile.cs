using AutoMapper;
using PryanikiTask.Application.Dto.Products;
using PryanikiTask.Domain.Entities;

namespace PryanikiTask.Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ProductCollectionDto>().ReverseMap();
        }
    }
}
