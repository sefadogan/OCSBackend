using OCS.Entities.Abstract;

namespace OCS.Entities.Concrete;

// District, City'e
// City ise Contry'e bağlı şekilde düşünülebilir.
// bu case özelinde detaylandırmadım.

public class District : EntityBase<int>
{
    public string Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
}

