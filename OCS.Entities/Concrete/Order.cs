using OCS.Entities.Abstract;
using static OCS.Entities.Constants.OrderConstants;

namespace OCS.Entities.Concrete;

public class Order : EntityBase<long>
{
    public int CustomerId { get; set; }
    public int DistrictId { get; set; }
    public string OrderTrackingNo { get; set; }
    public string ShipmentTrackingNo { get; set; }
    public OrderStatus Status { get; set; }
    public bool ReleasedForDistribution { get; set; }
    public DateTime CreatedDate { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual District District { get; set; }
}
