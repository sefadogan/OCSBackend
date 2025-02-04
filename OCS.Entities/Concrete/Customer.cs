using OCS.Entities.Abstract;

namespace OCS.Entities.Concrete;

public class Customer : EntityBase<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
}

