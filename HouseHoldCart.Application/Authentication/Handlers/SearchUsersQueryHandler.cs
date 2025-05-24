using HouseHoldCart.Application.Auth.Queries;
using HouseHoldCart.DataAccess.Interfaces;
using HouseHoldCart.Models.Authentication;
using MediatR;

namespace HouseHoldCart.Application.Authentication.Handlers
{
    public class SearchUsersQueryHandler(IUserDataAccess _userDataAccess): IRequestHandler<SearchUsersQuery, IEnumerable<User>>
    {
        public async Task<IEnumerable<User>> Handle(SearchUsersQuery query, CancellationToken cancellationToken)
        {
            return await _userDataAccess.SearchAsync("");
        }
    }
}
