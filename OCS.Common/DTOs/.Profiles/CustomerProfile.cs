using AutoMapper;
using OCS.Common.DTOs.Orders;
using OCS.Entities.Concrete;

namespace OCS.Common.DTOs.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();
        }
    }
}
