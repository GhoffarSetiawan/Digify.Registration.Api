using Digify.Registration.Application.Models;
using Digify.Registration.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Infrastructure.Repositories
{
    public abstract class BusinessRepositoryBase<T> : RepositoryBase<T>, IBusinessRepository<T> where T : class, IApplicationModel
    {
        protected BusinessRepositoryBase(AppDbContext context) : base(context)
        {

        }

        public virtual Task DeleteAsync(Guid id, Guid userId)
        {
            return Task.Run(() =>
            {
                T? entity = FindAsync(id).Result;

                if (entity != null)
                {
                    entity.Deleted = true;
                    entity.DeletedDate = DateTime.Now;
                    entity.DeletedUserId = userId;
                }
            });
        }

        public virtual Task InsertAsync(T entity)
        {
            return Task.Run(() => { _context.Set<T>().Add(entity); });
        }

        public virtual Task UpdateAsync(T entity)
        {
            return Task.Run(() => { _context.Set<T>().Update(entity); });
        }
    }
}
