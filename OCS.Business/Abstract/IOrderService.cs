using OCS.Common.DTOs.Orders;
using OCS.Common.Result.Abstract;

namespace OCS.Business.Abstract
{
    public interface IOrderService
    {
        Task<IDataResult<ICollection<OrderDto>>> GetOrdersAsync();
    }
}
