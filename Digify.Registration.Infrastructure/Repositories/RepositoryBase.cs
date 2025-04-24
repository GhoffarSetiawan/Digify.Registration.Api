using Microsoft.EntityFrameworkCore;
using Digify.Registration.Application.Models;
using Digify.Registration.Application.SelectParameters;
using Digify.Registration.Application.Services;
using Digify.Registration.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class, IApplicationModel
    {
        protected readonly AppDbContext _context;
        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }
        public virtual async Task<T?> FindAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<SelectResult<T>> SelectAsync(ISelectParameter selectParameter)
        {
            // Base query
            var query = _context.Set<T>().AsQueryable();
                       

            // Dynamic sorting
            query = selectParameter.SortBy switch
            {              
                _ => selectParameter.SortDirection == SortDirection.Descending ? query.OrderByDescending(p => p.Id) : query.OrderBy(p => p.Id)  // Default sorting by Id
            };

            // Paging
            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalItems / selectParameter.PageSize);

            var entities = await query.Skip((selectParameter.Page - 1) * selectParameter.PageSize)
                                      .Take(selectParameter.PageSize)
                                      .ToListAsync();

            // Return paginated and sorted result with metadata
            SelectResult<T> result = new SelectResult<T>();
            result.TotalItems = totalItems;
            result.TotalPages = totalPages;
            result.CurrentPage = selectParameter.Page;
            result.PageSize = selectParameter.PageSize;
            result.Data = entities;

            return result;
        }
    }
}
