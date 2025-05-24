using HouseHoldCart.Application.Authentication.Interfaces;
using HouseHoldCart.Application.Authentication.Queries;
using HouseHoldCart.Application.Authentication.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HouseHoldCart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(
        IOtpService _otpService, 
        ITokenService _tokenService, 
        IConfiguration _config, 
        IMediator _mediator) : ControllerBase
    {
        [HttpPost("[Action]")]
        public async Task<IActionResult> SendOtp([FromBody] SendOtpCommand command)
        {
            // Check if mobile number exists - if not, create user automatically (optional).
            SearchUsersQuery userQuery = new(){
                MobileNumber = command.MobileNumber
            };

            var users = await _mediator.Send(userQuery);
            var user = users?.FirstOrDefault();

            if (user == null)
            {
                var userCommand = new CreateUserCommand { MobileNumber = command.MobileNumber };
                await _mediator.Send(userCommand);
            }

            var otp = await _otpService.GenerateOtpAsync(command.MobileNumber);

            // TODO: Send OTP via SMS

            return Ok(new { Message = "OTP sent", Otp = otp }); // Remove OTP from response in prod
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpCommand command)
        {
            var isValid = await _otpService.ValidateOtpAsync(command.MobileNumber, command.Otp);
            if (!isValid) return Unauthorized(new { Message = "Invalid or expired OTP" });

            SearchUsersQuery userQuery = new(){
                MobileNumber = command.MobileNumber
            };

            var users = await _mediator.Send(userQuery);
            var user = users?.FirstOrDefault();
            if (user == null) return Unauthorized(new { Message = "User not found" });

            // Generate JWT
            var jwtKey = _config["Jwt:Key"];
            var jwtIssuer = _config["Jwt:Issuer"];
            if (jwtKey == null || jwtIssuer == null)
                return Unauthorized(new { Message = "Error signing in" });

            var token = _tokenService.GenerateAccessToken(user, jwtKey, jwtIssuer);
            if (string.IsNullOrEmpty(token)) return Unauthorized(new { Message = "Error signing in" });

            return Ok(new { Token = token });
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
        {
            var storedToken = await _tokenService.GetStoredTokenAsync(command.Token);

            if (storedToken == null || storedToken.IsRevoked || storedToken.Expires <= DateTime.UtcNow)
                return Unauthorized(new { Message = "Invalid or expired refresh token" });

            // Revoke old refresh token
            storedToken.IsRevoked = true;
            await _tokenService.UpdateAsync(storedToken);

            var jwtKey = _config["Jwt:Key"];
            var jwtIssuer = _config["Jwt:Issuer"];
            if (jwtKey == null || jwtIssuer == null)
                return Unauthorized(new { Message = "Error signing in" });

            // Generate new tokens
            var newAccessToken = _tokenService.GenerateAccessToken(storedToken.User, jwtKey, jwtIssuer);
            if(string.IsNullOrEmpty(newAccessToken)) return Unauthorized(new { Message = "Error signing in" });

            var newRefreshToken = _tokenService.GenerateRefreshToken();
            newRefreshToken.UserId = storedToken.UserId;

            await _tokenService.CreateAsync(newRefreshToken);

            return Ok(new
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken.Token
            });
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Logout()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

            // Revoke all active refresh tokens for the user
            var tokens = await _context.RefreshTokens
                .Where(t => t.UserId == userId && !t.IsRevoked && t.Expires > DateTime.UtcNow)
                .ToListAsync();

            foreach (var token in tokens)
            {
                token.IsRevoked = true;
            }

            await _context.SaveChangesAsync();

            return Ok(new { Message = "Logged out successfully" });
        }
    }
}
