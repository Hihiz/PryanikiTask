using AutoMapper;
using PryanikiTask.Application.Dto.Orders;
using PryanikiTask.Domain.Entities;

namespace PryanikiTask.Application.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();
        }
    }
}
