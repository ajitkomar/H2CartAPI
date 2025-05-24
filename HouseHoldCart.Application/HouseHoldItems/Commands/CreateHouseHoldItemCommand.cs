using MediatR;
using HouseHoldCart.Models.HouseHoldItems;

namespace HouseHoldCart.Application.HouseHoldItems.Commands
{
    public class CreateHouseHoldItemCommand(HouseHoldItem item) : IRequest<HouseHoldItem>
    {
        public HouseHoldItem Item { get; set; } = item;
    }
}