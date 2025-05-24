using HouseHoldCart.Models.Enum;

namespace HouseHoldCart.Models.Logistics
{
    public class LogisticsInfo
    {
        public int Id { get; set; }
        public int OrderId { get; set; } 
        public Address PickupAddress { get; set; }     
        public Address DropAddress { get; set; }       
        public DateTime ScheduledPickupTime { get; set; }
        public DateTime? ActualPickupTime { get; set; }
        public DateTime? DeliveryTime { get; set; }
        public LogisticsStatus Status { get; set; }

        // Third-party provider details
        public string ProviderName { get; set; }       
        public string ProviderContactNumber { get; set; }
        public string TrackingUrl { get; set; }
    }
}
