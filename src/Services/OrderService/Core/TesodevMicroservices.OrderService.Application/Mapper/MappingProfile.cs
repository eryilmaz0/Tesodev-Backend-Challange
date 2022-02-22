using AutoMapper;
using TesodevMicroservices.Core.Entity.Child;
using TesodevMicroservices.OrderService.Application.Dto;
using TesodevMicroservices.OrderService.Application.ViewModel;
using TesodevMicroservices.OrderService.Domain.Entity;
using TesodevMicroservices.OrderService.Domain.OwnedEntity;

namespace TesodevMicroservices.OrderService.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateOrderDto, Order>().ReverseMap();
            CreateMap<UpdateOrderDto, Order>().ReverseMap();
            CreateMap<Order, ListOrdersViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<CreateAddressDto, Address>().ReverseMap();
            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<UpdateAddressDto, Address>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();
        }
    }
}