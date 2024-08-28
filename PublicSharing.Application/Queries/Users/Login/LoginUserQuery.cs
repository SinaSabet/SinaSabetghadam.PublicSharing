using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Queries.Users.Login
{
    public record LoginUserQuery(string Email,string Password):IRequest<LoginUserResponseQuery>;
  
}
