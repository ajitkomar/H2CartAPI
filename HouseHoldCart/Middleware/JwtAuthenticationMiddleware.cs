using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HouseHoldCart.Middleware
{
    public class JwtAuthenticationMiddleware(RequestDelegate next, IConfiguration config)
    {
        private readonly RequestDelegate _next = next;
        private readonly IConfiguration _config = config;

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                AttachUserToContext(context, token);

            await _next(context); // Proceed to next middleware
        }

        private void AttachUserToContext(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _config["Jwt:Issuer"],
                    ValidAudience = _config["Jwt:Issuer"],
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

                // Attach user ID to HttpContext for use downstream
                context.Items["UserId"] = userId;

                // Optionally add roles or other claims
                var role = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
                context.Items["UserRole"] = role;
            }
            catch
            {
                throw new Exception("Unauthorized to acccess");
                // Don't attach user if JWT validation fails — request won't have access to protected routes
            }
        }
    }

}
