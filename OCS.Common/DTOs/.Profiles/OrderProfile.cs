using AutoMapper;
using OCS.Common.DTOs.Orders;
using OCS.Entities.Concrete;

namespace OCS.Common.DTOs.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
        }
    }
}
