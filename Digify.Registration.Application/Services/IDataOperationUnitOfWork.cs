using Digify.Registration.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Application.Services
{
    public interface IUnitOfWork<T> : IUnitOfWork where T : class, IApplicationModel
    {
        IBusinessRepository<T> Repository { get; }
    }
}
