using Digify.Registration.Application.Models;
using Digify.Registration.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Application.UseCases.Companies
{
    public class FindCompanyUseCase(IBusinessRepository<CompanyApplicationModel> repository) : IUseCase<Guid, CompanyApplicationModel>
    {
        protected readonly IBusinessRepository<CompanyApplicationModel> _repository = repository;
        public async Task<CompanyApplicationModel?> Execute(Guid input)
        {
            return await _repository.FindAsync(input);
        }
    }
}
