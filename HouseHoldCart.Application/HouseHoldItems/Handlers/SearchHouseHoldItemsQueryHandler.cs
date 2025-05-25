using MediatR;
using HouseHoldCart.Models.HouseHoldItems;
using HouseHoldCart.Application.HouseHoldItems.Queries;
using HouseHoldCart.DataAccess.Interfaces;

namespace HouseHoldCart.Application.HouseHoldItems.Handlers
{
    public class SearchHouseHoldItemsQueryHandler(IHouseHoldItemDataAccess houseHoldItemDataAccess): IRequestHandler<SearchHouseHoldItemsQuery, IEnumerable<HouseHoldItem>>
    {
        public async Task<IEnumerable<HouseHoldItem>> Handle(SearchHouseHoldItemsQuery query, CancellationToken cancellationToken)
        {
            return await houseHoldItemDataAccess.SearchAsync("query");
        }
    }
}
