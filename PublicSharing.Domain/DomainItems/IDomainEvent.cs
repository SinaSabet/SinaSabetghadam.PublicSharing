﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicSharing.Domain.DomainItems
{
    public interface IDomainEvent
    {
        public DateTime CreatedAt { get; set; }
    }
}
