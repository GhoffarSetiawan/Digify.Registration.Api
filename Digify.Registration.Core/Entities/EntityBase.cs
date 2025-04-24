using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Core.Entities
{
    public abstract class EntityBase : IEntity
    {
        public required Guid Id { get; set; }       

    }
}
