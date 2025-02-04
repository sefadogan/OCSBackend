using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OCS.Business.Abstract;

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
        public async Task<IActionResult> Get()
        {
            return GetResponseOnlyResultData(await _orderService.GetOrdersAsync());
        }
    }
}
