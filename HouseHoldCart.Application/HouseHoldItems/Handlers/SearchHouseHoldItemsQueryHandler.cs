using MediatR;
using HouseHoldCart.Models.HouseHoldItems;
using HouseHoldCart.Application.HouseHoldItems.Queries;
using HouseHoldCart.DataAccess.Interfaces;

namespace HouseHoldCart.Application.HouseHoldItems.Handlers
{
    public class SearchHouseHoldItemsQueryHandler(IHouseHoldItemDataAccess houseHoldItemDataAccess): IRequestHandler<SearchHouseHoldItemsQuery, List<HouseHoldItem>>
    {
        public async Task<List<HouseHoldItem>> Handle(SearchHouseHoldItemsQuery query, CancellationToken cancellationToken)
        {
            return await houseHoldItemDataAccess.SearchAsync("query");
        }
    }
}
