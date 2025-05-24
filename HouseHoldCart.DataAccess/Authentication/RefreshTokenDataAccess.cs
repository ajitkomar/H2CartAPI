using HouseHoldCart.DataAccess.Interfaces;
using HouseHoldCart.Models.Authentication;
using Microsoft.EntityFrameworkCore;

namespace HouseHoldCart.DataAccess.Authentication
{
    public class RefreshTokenDataAccess(AppDbContext _context): CrudOperation<RefreshToken>(_context), IRefreshTokenDataAccess
    {
        public async Task<RefreshToken> RefreshTokenWithUserAsync(string token)
        {
            return await _context.RefreshTokens.Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Token == token) ?? new RefreshToken();
        }
    }
}
