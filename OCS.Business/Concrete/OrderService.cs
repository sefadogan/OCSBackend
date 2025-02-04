using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using OCS.Business.Abstract;
using OCS.Common.DTOs.Orders;
using OCS.Common.OData;
using OCS.Common.Pagination;
using OCS.Common.Result.Abstract;
using OCS.Common.Result.Concrete;
using OCS.DataAccess.Abstract;
using System.Collections;

namespace OCS.Business.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IPaginationUriService _paginationUriService;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IMapper mapper, IPaginationUriService paginationUriService, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _paginationUriService = paginationUriService;
            _orderRepository = orderRepository;
        }

        public async Task<IDataResult<IEnumerable>> GetOrdersAsync(PaginationFilter paginationFilter, ODataQueryOptions<OrderDto> queryOptions)
        {
            var orders = _orderRepository.Queryable()
                .Include(o => o.Customer)
                .Include(o => o.District)
                .ProjectTo<OrderDto>(_mapper.ConfigurationProvider);
            if (!orders.Any())
                return new SuccessDataResult<IEnumerable<OrderDto>>();

            return await ODataHelper.ApplyODataToPaginatedResult(
                paginationFilter,
                queryOptions,
                orders,
                _paginationUriService,
                ODataHelper.GetDefaultSettings());
        }
    }
}
