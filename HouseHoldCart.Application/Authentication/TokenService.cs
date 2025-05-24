using HouseHoldCart.Application.Authentication.Interfaces;
using HouseHoldCart.DataAccess.Interfaces;
using HouseHoldCart.Models.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace HouseHoldCart.Application.Authentication
{
    public class TokenService(IRefreshTokenDataAccess _refreshTokenDataAccess) : ITokenService
    {
        public string GenerateAccessToken(User user, string jwtKey, string jwtIssuer)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.MobilePhone, user.MobileNumber),
                new Claim(ClaimTypes.Role, user.IsSeller ? "Seller" : "Buyer")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtIssuer,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15), // shorter-lived access token
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public RefreshToken GenerateRefreshToken()
        {
            var randomBytes = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomBytes),
                Expires = DateTime.UtcNow.AddDays(7), // refresh token valid for 7 days
                IsRevoked = false
            };
        }

        public async Task<RefreshToken> GetStoredTokenAsync(string token)
        {
            return await _refreshTokenDataAccess.RefreshTokenWithUserAsync(token);
        }

        public async Task<RefreshToken> UpdateAsync(RefreshToken refreshToken)
        {
            return await _refreshTokenDataAccess.UpdateAsync(refreshToken);
        }

        public async Task<RefreshToken> CreateAsync(RefreshToken refreshToken)
        {
            return await _refreshTokenDataAccess.CreateAsync(refreshToken);
        }
    }
}
