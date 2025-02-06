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
using OCS.Entities.Concrete;
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
            /*
             * ilgili parametrelerin key'lerine göre veriler cache'deyse cache'den çekilip return edilebilir.
             * değilse db'den okuyup, cache'e eklenip return edilebilir.
             * 
             * scheduled olarak cache doldurulabilir.
             */

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

        public async Task<IDataResult<OrderDto>> GetOrderByIdAsync(int id)
        {
            /*
             * ilgili veri cache'deyse cache'den çekilip return edilebilir.
             * değilse db'den okuyup, cache'e eklenip return edilebilir.
             * 
             * ancak anlık veri trafiğinin yoğun olduğu durumlarda örneğin push notification,
             * cache'in boş olması anlık yoğun bir DB trafiği yaratacaktır.
             * bu sebeple scheduled olarak ilgili cache'in doldurulması sağlanabilir.
             * 
             * basit seviyede getbyid için örnek sağlandı.
             */

            var order = await _orderRepository.GetById(id);
            if (order == null)
                return new ErrorDataResult<OrderDto>("Sipariş bulunamadı.");

            var orderDto = _mapper.Map<OrderDto>(order);
            return new SuccessDataResult<OrderDto>(orderDto);
        }
    }
}
