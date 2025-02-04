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
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IDataResult<ICollection<OrderDto>>> GetOrdersAsync()
        {
            var result = await _orderRepository.Queryable()
                .Include(o => o.Customer)
                .Include(o => o.District)
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    OrderTrackingNo = o.OrderTrackingNo,
                    ShipmentTrackingNo = o.ShipmentTrackingNo,
                    Status = o.Status,
                    ReleasedForDistribution = o.ReleasedForDistribution,
                    CreatedDate = o.CreatedDate,
                    Customer = new CustomerDto
                    {
                        Id = o.CustomerId,
                        FirstName = o.Customer.FirstName,
                        LastName = o.Customer.LastName
                    },
                    District = new DistrictDto
                    {
                        Id = o.DistrictId,
                        Name = o.District.Name
                    }
                })
                .ToListAsync();

            return new SuccessDataResult<ICollection<OrderDto>>(result);
        }
    }
}
