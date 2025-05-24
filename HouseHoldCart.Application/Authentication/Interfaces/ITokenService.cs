using HouseHoldCart.Models.Authentication;
namespace HouseHoldCart.Application.Authentication.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user, string jwtKey, string jwtIssuer);
        RefreshToken GenerateRefreshToken();
        Task<RefreshToken> GetStoredTokenAsync(string token);
        Task<RefreshToken> UpdateAsync(RefreshToken refreshToken);
        Task<RefreshToken> CreateAsync(RefreshToken refreshToken);
    }
}
