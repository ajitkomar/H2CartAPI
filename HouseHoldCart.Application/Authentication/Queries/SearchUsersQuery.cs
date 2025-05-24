using MediatR;
using HouseHoldCart.Models.Authentication;

namespace HouseHoldCart.Application.Authentication.Queries
{
    public class SearchUsersQuery : IRequest<IEnumerable<User>>
    {
        public string MobileNumber { get; set; } = null!;
        public string? Name { get; set; }
    }
}
