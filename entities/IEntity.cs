using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spraynprayscore.api.entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
