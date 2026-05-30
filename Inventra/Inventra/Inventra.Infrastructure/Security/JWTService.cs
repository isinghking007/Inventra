using Inventra.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Inventra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Inventra.Infrastructure.Security
{
    public class JWTService : IJWTService
    {
        public readonly IConfiguration _configuration;
        public JWTService(IConfiguration configuration) 
        { 
            _configuration = configuration;
        }
        string IJWTService.GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim("user id",user.Id.ToString()),
                new Claim("fullname",user.FullName),
                new Claim("phone",user.Phone)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var duration=Convert.ToInt32(_configuration["JWT:DurationInMinutes"]);
            var token = new JwtSecurityToken(
                _configuration["JWT:Issuer"],
                _configuration["JWT:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(duration),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
