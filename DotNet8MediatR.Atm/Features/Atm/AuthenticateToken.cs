using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DotNet8MediatR.Models.Authenticate;
using DotNet8MediatR.Models.JwtModels;
using DotNet8MediatR.Shared;
using Microsoft.Extensions.Configuration;

namespace DotNet8MediatR.Atm.Features.Atm
{
    public class AuthenticateToken
    {
        private readonly IConfiguration _configuration;
        public AuthenticateToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AuthenticateTokenResponseModel? GenerateToken
            (AuthenticateTokenRequestModel? requestModel)
        {
            if (requestModel is null) return null;

            AuthenticateTokenResponseModel model = new AuthenticateTokenResponseModel();
            var claims = new List<Claim>();
            claims.Add(new Claim("UserName", requestModel.UserName));
            claims.Add(new Claim("CardNumber", requestModel.CardNumber));

            // Add roles as multiple claims
            foreach (var role in requestModel.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            JwtRequestModel jwtRequestModel = new JwtRequestModel
            (
                requestModel.UserName,
                _configuration["Jwt:Secret"],
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                TimeSpan.FromMinutes(10),
                claims.ToArray()
            );
            var token = JwtHelper.GetJwtToken(jwtRequestModel);
            var expires = token.ValidTo;

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            model.AccessToken = accessToken;
            model.ValidTo = expires;
            return model;
        }

        //protected AuthenticateTokenRequestModel? GetClaims()
        //{
        //    if (User is null) return null;
        //    var cardNumber = User.FindFirst("CardNumber")?.Value;
        //    var userName = User.FindFirst("UserName")?.Value;
        //    string[] userRoles = User.FindAll(ClaimTypes.Role).ToList().Select(x => x.Value).ToArray();
        //    return new AuthenticateTokenRequestModel
        //    {
        //        UserName = userName,
        //        CardNumber = cardNumber,
        //        UserRoles = userRoles
        //    };
        //}

        protected AuthenticateTokenResponseModel? GetToken
            (AuthenticateTokenRequestModel requestModel)
        {
            //return GenerateToken(GetClaims());
            return GenerateToken(requestModel);
        }
    }
}
