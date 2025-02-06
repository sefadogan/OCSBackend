using Microsoft.AspNetCore.OData.Query;
using OCS.Common.DTOs.Orders;
using OCS.Common.Pagination;
using OCS.Common.Result.Abstract;
using System.Collections;

namespace OCS.Business.Abstract
{
    public interface IOrderService
    {
        Task<IDataResult<IEnumerable>> GetOrdersAsync(PaginationFilter paginationFilter, ODataQueryOptions<OrderDto> queryOptions);
        Task<IDataResult<OrderDto>> GetOrderByIdAsync(int id);
    }
}
