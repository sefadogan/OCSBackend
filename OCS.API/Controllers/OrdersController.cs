using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using OCS.Business.Abstract;
using OCS.Common.DTOs.Orders;
using OCS.Common.Pagination;

namespace OCS.API.Controllers
{
    [AllowAnonymous]
    public class OrdersController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationFilter paginationFilter, ODataQueryOptions<OrderDto> queryOptions)
        {
            return GetResponseOnlyResultData(await _orderService.GetOrdersAsync(paginationFilter, queryOptions));
        }
    }
}
