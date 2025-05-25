using HouseHoldCart.Models.Authentication;

namespace HouseHoldCart.DataAccess.Interfaces
{
    public interface IRefreshTokenDataAccess: ICrudOperation<RefreshToken>
    {
        Task<RefreshToken> RefreshTokenIncludingUserAsync(string token);
        Task RevokeAllTokenOfUser(int user);
    }
}
