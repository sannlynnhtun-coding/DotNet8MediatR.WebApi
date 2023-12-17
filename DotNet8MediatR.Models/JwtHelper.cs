using DotNet8MediatR.Models.JwtModels;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Shared
{
    public class JwtHelper
    {
        public static JwtSecurityToken GetJwtToken(JwtRequestModel requestModel)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, requestModel.UserName),
                // this guarantees the token is unique
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            if (requestModel.AdditionalClaims is object)
            {
                var claimList = new List<Claim>(claims);
                claimList.AddRange(requestModel.AdditionalClaims);
                claims = claimList.ToArray();
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(requestModel.SigningKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                issuer: requestModel.Issuer,
                audience: requestModel.Audience,
                expires: DateTime.UtcNow.Add(requestModel.Expiration),
                claims: claims,
                signingCredentials: creds
            );
        }
    }
}
