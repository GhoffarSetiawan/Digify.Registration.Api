using Digify.Registration.Application.Models;
using Digify.Registration.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Application.Services
{
    public interface IBusinessRepository<T> : IRepository<T> where T : class, IApplicationModel
    {
        Task InsertAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteAsync(Guid id, Guid userId);
    }
}
