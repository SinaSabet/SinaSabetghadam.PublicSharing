using Microsoft.AspNetCore.Http;
using PublicSharing.Application.Services.Jwt;
using PublicSharing.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Infrastructure.Services
{
    public class CurrentUserProvider(IHttpContextAccessor _httpContextAccessor) : ICurrentUserProvider
    {
        public CurrentUser GetCurrentUser()
        {

            var id = Guid.Parse(GetSingleClaimValue("id"));
            var firstName = GetSingleClaimValue(JwtRegisteredClaimNames.Name);
            var userid=new UserId() { Value = id };
            return new CurrentUser(userid, firstName);
        }


        private string GetSingleClaimValue(string claimType) =>
            _httpContextAccessor.HttpContext!.User.Claims
                .Single(claim => claim.Type == claimType)
                .Value;
    }
}
