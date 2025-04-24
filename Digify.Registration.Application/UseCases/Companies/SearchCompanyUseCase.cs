using Digify.Registration.Application.Models;
using Digify.Registration.Application.SelectParameters;
using Digify.Registration.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Application.UseCases.Companies
{
    public class SearchCompanyUseCase(IBusinessRepository<CompanyApplicationModel> repository) : IUseCase<CompanySelectParameter, SelectResult<CompanyApplicationModel>>
    {
        protected readonly IBusinessRepository<CompanyApplicationModel> _repository = repository;
        public async Task<SelectResult<CompanyApplicationModel>?> Execute(CompanySelectParameter input)
        {
            return await _repository.SelectAsync(input);
        }
    }
}
