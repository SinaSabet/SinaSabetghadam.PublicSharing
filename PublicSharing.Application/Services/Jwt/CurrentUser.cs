using PublicSharing.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Services.Jwt
{
    public record CurrentUser(UserId Id,string FirstName);
   
}
