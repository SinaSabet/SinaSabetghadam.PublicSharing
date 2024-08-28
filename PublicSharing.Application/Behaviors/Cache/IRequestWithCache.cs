using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Application.Behaviors.Cache
{
    internal interface IRequestWithCache<TResponse>:IRequest<TResponse>, IRequestWithCache
    {
    }

    internal interface IRequestWithCache
    {
    }
}
