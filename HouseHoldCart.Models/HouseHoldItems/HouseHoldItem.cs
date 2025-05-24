using HouseHoldCart.Models.Enum;

namespace HouseHoldCart.Models.HouseHoldItems
{
    public class HouseHoldItem
    {
        public int Id { get; set; }
        public string Title { get; set; }           // e.g., "Samsung 6kg Washing Machine"
        public string Description { get; set; }
        public ItemCategory Category { get; set; }  // Electronics, Furniture, etc.
        public decimal Price { get; set; }
        public ItemCondition Condition { get; set; }
        public string Location { get; set; }        // City or ZIP
        public DateTime ListedDate { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int SellerId { get; set; }           // Hidden from buyer
        public List<string> ImageUrls { get; set; }
    }
}
