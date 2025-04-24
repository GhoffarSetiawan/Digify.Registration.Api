using Digify.Registration.Application.Models;
using Digify.Registration.Application.SelectParameters;
using Digify.Registration.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Application.Services
{
    public interface IRepository<T> where T : class, IApplicationModel
    {
        Task<T?> FindAsync(Guid id);
        Task<SelectResult<T>> SelectAsync(ISelectParameter parameter);
    }
}
