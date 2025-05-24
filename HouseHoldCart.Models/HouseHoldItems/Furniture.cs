using HouseHoldCart.Models.Enum;

namespace HouseHoldCart.Models.HouseHoldItems
{
    public class Furniture : HouseHoldItem
    {
        public FurnitureMaterial Material { get; set; }  // e.g., Engineered Wood, Solid Wood
        public Dimensions Size { get; set; }
        public string Color { get; set; }
        public bool RequiresAssembly { get; set; }
    }
}
