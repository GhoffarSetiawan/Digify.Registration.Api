using Digify.Registration.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Application.Models
{
    public interface IApplicationModel : IEntity
    {
        bool Deleted { get; set; }
        DateTime? CreatedDate { get; set; }
        Guid? CreatedUserId { get; set; }
        DateTime? UpdatedDate { get; set; }
        Guid? UpdatedUserId { get; set; }
        DateTime? DeletedDate { get; set; }
        Guid? DeletedUserId { get; set; }
    }
}
