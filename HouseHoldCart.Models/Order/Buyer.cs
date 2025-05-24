namespace HouseHoldCart.Models.Order
{
    public class Buyer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<int> FavoriteItemIds { get; set; }
    }
}
