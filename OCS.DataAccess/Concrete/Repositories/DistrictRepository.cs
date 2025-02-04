using DataAccess.Concrete.Repository.Base;
using OCS.DataAccess.Abstract;
using OCS.DataAccess.Concrete.EntityFramework;
using OCS.Entities.Concrete;

namespace OCS.DataAccess.Concrete.Repositories
{
    public class DistrictRepository : EntityRepositoryBase<District, int>, IDistrictRepository
    {
        public DistrictRepository(OCSDbContext context) : base(context)
        {
        }
    }
}
