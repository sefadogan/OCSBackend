using static OCS.Entities.Constants.OrderConstants;

namespace OCS.Common.DTOs.Orders
{
    public class OrderDto
    {
        public int OrderNo { get; set; }
        public string OrderTrackingNo { get; set; }
        public string ShipmentTrackingNo { get; set; }
        public string CustomerName { get; set; }
        public string DistrictName { get; set; }
        public OrderStatus Status { get; set; }
        public bool ReleasedForDistribution { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
