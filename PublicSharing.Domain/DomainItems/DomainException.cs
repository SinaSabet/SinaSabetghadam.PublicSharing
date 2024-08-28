﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Domain.DomainItems
{
    public abstract class DomainException:Exception
    {
        protected DomainException() : base() { }

        protected DomainException(string? message) : base(message) { }
    }
}