using DataAccess.Concrete.Repository.Base;
using OCS.DataAccess.Abstract;
using OCS.DataAccess.Concrete.EntityFramework;
using OCS.Entities.Concrete;

namespace OCS.DataAccess.Concrete.Repositories
{
    public class CustomerRepository : EntityRepositoryBase<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(OCSDbContext context) : base(context)
        {
        }
    }
}
