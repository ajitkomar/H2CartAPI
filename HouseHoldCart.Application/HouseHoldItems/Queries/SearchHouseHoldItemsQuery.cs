using MediatR;
using HouseHoldCart.Models.HouseHoldItems;
using HouseHoldCart.Models.Enum;

namespace HouseHoldCart.Application.HouseHoldItems.Queries
{
    public class SearchHouseHoldItemsQuery: IRequest<IEnumerable<HouseHoldItem>>
    {
        public ItemCategory? Category { get; set; }
        public ItemCondition? Condition { get; set; }
    }
}
