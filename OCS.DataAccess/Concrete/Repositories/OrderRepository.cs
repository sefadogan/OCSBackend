using DataAccess.Concrete.Repository.Base;
using OCS.DataAccess.Abstract;
using OCS.DataAccess.Concrete.EntityFramework;
using OCS.Entities.Concrete;

namespace OCS.DataAccess.Concrete.Repositories
{
    public class OrderRepository : EntityRepositoryBase<Order, long>, IOrderRepository
    {
        public OrderRepository(OCSDbContext context) : base(context)
        {
        }
    }
}
