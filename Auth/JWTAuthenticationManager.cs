using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UniqueTodoApplication.DTOs;

namespace UniqueTodoApplication.Auth
{
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        private readonly string _key;

        public JWTAuthenticationManager(string key)
        {
            _key = key;
        }
        public string GenerateToken(UserDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };
            foreach (var item in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item.Name));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
