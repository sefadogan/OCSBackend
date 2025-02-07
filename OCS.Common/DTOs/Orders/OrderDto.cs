namespace OCS.Common.DTOs.Orders
{
    public class OrderDto
    {
        public long Id { get; set; }
        public string OrderTrackingNo { get; set; }
        public string ShipmentTrackingNo { get; set; }
        public int Status { get; set; } //OrderStatus
        public bool ReleasedForDistribution { get; set; }
        public DateTime CreatedDate { get; set; }

        public CustomerDto Customer { get; set; }
        public DistrictDto District { get; set; }
    }
}
