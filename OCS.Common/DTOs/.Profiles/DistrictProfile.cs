using AutoMapper;
using OCS.Common.DTOs.Orders;
using OCS.Entities.Concrete;

namespace OCS.Common.DTOs.Profiles
{
    public class DistrictProfile : Profile
    {
        public DistrictProfile()
        {
            CreateMap<District, DistrictDto>();
        }
    }
}
