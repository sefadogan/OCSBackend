namespace OCS.Entities.Constants
{
    public static class OrderConstants
    {
        public enum OrderStatus
        {
            Created = 0,
            Canceled = 1,
            Delivered = 2,
            Waiting = 3,
            NotDelivered = 4
        }
    }
}
