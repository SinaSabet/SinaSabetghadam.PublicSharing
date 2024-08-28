using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Commands.Users.RegisterUser
{
    public record RegisterUserCommand(string Email,string FirstName,string LastName,string Password):IRequest<RegisterUserCommandResponse>;
  
}
