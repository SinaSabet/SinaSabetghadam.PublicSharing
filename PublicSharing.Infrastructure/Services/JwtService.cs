using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using PublicSharing.Application.Commands.Tweets.CreateTweet;
using PublicSharing.Application.Services.Jwt;
using PublicSharing.Domain.TweetAggregate;
using PublicSharing.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Infrastructure.Services
{
    public class JwtService(IOptions<JwtSettings> jwtSettings ) : IJwtService
    {
        private readonly JwtSettings _jwtSettings = jwtSettings.Value;
        public string GenerateToken(User user)
        {
            var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Name, user.FirstName),
            new(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new("id", user.Id.Value.ToString()),
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                    signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    


    }
}
