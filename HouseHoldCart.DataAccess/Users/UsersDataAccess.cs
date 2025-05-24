using HouseHoldCart.DataAccess.Interfaces;
using HouseHoldCart.Models.Authentication;

namespace HouseHoldCart.DataAccess.Users
{
    public class UsersDataAccess(AppDbContext _context): CrudOperation<User>(_context), IUserDataAccess
    {
    }
}
