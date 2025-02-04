using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OCS.Business.Abstract;
using OCS.Common.DTOs.Orders;
using OCS.Common.Result.Abstract;
using OCS.Common.Result.Concrete;
using OCS.DataAccess.Abstract;

namespace OCS.Business.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<IDataResult<ICollection<OrderDto>>> GetOrdersAsync()
        {
            var result = await _orderRepository.Queryable()
                .Include(o => o.Customer)
                .Include(o => o.District)
                .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new SuccessDataResult<ICollection<OrderDto>>(result);
        }
    }
}
