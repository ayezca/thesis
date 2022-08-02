using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MedicalDB
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User _applicationUser;
        private CustomToken _customToken;

        public AuthenticationManager(IConfiguration configuration, UserManager<User> userManager)
        {
            _customToken = new CustomToken();
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            _applicationUser = await _userManager.FindByNameAsync(userForAuth.UserName);
            if (_applicationUser != null &&
                await _userManager.CheckPasswordAsync(_applicationUser, userForAuth.Password))
            {
                _customToken.Profile = new ProfileDto
                {
                    FirstName = _applicationUser.FirstName,
                    LastName = _applicationUser.LastName,
                    PhoneNumber = _applicationUser.PhoneNumber,
                    Email = _applicationUser.Email,
                };
                return true;
            }

            return false;
        }

        public async Task<CustomToken> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            _customToken.Token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return _customToken;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings").GetSection("secretKey").Value);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _applicationUser.UserName)
            };
            var roles = await _userManager.GetRolesAsync(_applicationUser);
            foreach (var role in roles)
            {
                _customToken.Profile.Roles.Add(role);
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("validIssuer").Value,
                audience: jwtSettings.GetSection("validAudience").Value, claims: claims,
                expires:
                DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("expires").Value)),
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
    }
}