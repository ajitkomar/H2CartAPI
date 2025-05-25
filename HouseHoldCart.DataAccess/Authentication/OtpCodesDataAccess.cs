using HouseHoldCart.DataAccess.Interfaces;
using HouseHoldCart.Models.Authentication;

namespace HouseHoldCart.DataAccess.Authentication
{
    public class OtpCodesDataAccess(AppDbContext _context): CrudOperation<OtpCode>(_context), IOtpCodesDataAccess
    {
    }
}
