using HouseHoldCart.DataAccess.Interfaces;
using HouseHoldCart.Models.Authentication;
using Microsoft.EntityFrameworkCore;

namespace HouseHoldCart.DataAccess.Authentication
{
    public class RefreshTokenDataAccess(AppDbContext _context): CrudOperation<RefreshToken>(_context), IRefreshTokenDataAccess
    {
        public async Task<RefreshToken> RefreshTokenIncludingUserAsync(string token)
        {
            return await _context.RefreshTokens.Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Token == token) ?? new RefreshToken();
        }

        public async Task RevokeAllTokenOfUser(int userId)
        {
            var tokens = await _context.RefreshTokens
               .Where(t => t.UserId == userId && !t.IsRevoked && t.Expires > DateTime.UtcNow)
               .ToListAsync();

            foreach (var token in tokens)
            {
                token.IsRevoked = true;
            }

            await _context.SaveChangesAsync();
        }
    }
}
