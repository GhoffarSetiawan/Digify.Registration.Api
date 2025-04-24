using Digify.Registration.Application.Models;
using Digify.Registration.Application.Services;
using Digify.Registration.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Infrastructure.UnitOfWorks
{
    public class CompanyUnitOfWork(AppDbContext context, IBusinessRepository<CompanyApplicationModel> repository) : IUnitOfWork<CompanyApplicationModel>
    {
        protected readonly AppDbContext _context = context;
        protected readonly IBusinessRepository<CompanyApplicationModel> _repository = repository;
        public IBusinessRepository<CompanyApplicationModel> Repository { get => _repository; }

        public Task CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
