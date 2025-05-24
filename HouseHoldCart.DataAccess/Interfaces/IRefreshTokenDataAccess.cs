using HouseHoldCart.Models.Authentication;

namespace HouseHoldCart.DataAccess.Interfaces
{
    public interface IRefreshTokenDataAccess: ICrudOperation<RefreshToken>
    {
        Task<RefreshToken> RefreshTokenWithUserAsync(string token);
    }
}
