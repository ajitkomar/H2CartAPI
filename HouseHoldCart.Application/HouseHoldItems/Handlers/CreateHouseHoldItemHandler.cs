using MediatR;
using HouseHoldCart.Models.HouseHoldItems;
using HouseHoldCart.DataAccess.Interfaces;
using HouseHoldCart.Application.HouseHoldItems.Commands;

namespace HouseHoldCart.Application.HouseHoldItems.Handlers
{
    public class CreateHouseHoldItemHandler(IHouseHoldItemDataAccess houseHoldItemDataAccess) : IRequestHandler<CreateHouseHoldItemCommand, HouseHoldItem>
    {
        public async Task<HouseHoldItem> Handle(CreateHouseHoldItemCommand request, CancellationToken cancellationToken)
        {
            return await houseHoldItemDataAccess.CreateAsync(request.Item);
        }
    }
}
