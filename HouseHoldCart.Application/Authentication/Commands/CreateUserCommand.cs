using HouseHoldCart.Models.Authentication;
using MediatR;

namespace HouseHoldCart.Application.Authentication.Commands
{
    public class CreateUserCommand : User, IRequest<User>
    {
    }
}
