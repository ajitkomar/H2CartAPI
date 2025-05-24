namespace HouseHoldCart.Models.HouseHoldItems
{
    public class Electronics : HouseHoldItem
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public bool IsWorking { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string WarrantyInfo { get; set; }
    }
}
