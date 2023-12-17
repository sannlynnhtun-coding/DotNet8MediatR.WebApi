using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8MediatR.Models.JwtModels
{
    public record JwtRequestModel(
        string UserName,
        string SigningKey,
        string Issuer,
        string Audience,
        TimeSpan Expiration,
        Claim[] AdditionalClaims = null);
}
