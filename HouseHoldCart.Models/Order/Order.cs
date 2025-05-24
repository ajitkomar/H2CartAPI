using HouseHoldCart.Models.Enum;
using HouseHoldCart.Models.Logistics;

namespace HouseHoldCart.Models.Order
{
    public class Order
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int ItemId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public LogisticsInfo Logistics { get; set; }
    }
}
