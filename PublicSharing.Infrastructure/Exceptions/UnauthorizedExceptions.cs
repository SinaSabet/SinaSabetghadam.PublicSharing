using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Infrastructure.Exceptions
{
    public class UnauthorizedExceptions: Exception
    {
        public static string DefaultMessage = "Unauthorized access.";

        public UnauthorizedExceptions()
            : base(DefaultMessage)
        {
        }

        public UnauthorizedExceptions(string message)
            : base(message)
        {
        }

        public UnauthorizedExceptions(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
