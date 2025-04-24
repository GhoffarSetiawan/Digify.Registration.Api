using Digify.Registration.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Application.Models
{
    public abstract class ApplicationModelBase : EntityBase, IApplicationModel
    {
        public required bool Deleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Guid? DeletedUserId { get; set; }
    }
}
