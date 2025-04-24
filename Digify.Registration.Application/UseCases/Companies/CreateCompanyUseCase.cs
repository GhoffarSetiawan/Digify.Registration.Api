using FluentValidation;
using FluentValidation.Results;
using Digify.Registration.Application.Models;
using Digify.Registration.Application.Services;
using Digify.Registration.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Application.UseCases.Companies
{
    public class CreateCompanyUseCase(IUnitOfWork<CompanyApplicationModel> uow, IValidator<Company> validator) : IUseCase<CompanyApplicationModel, bool>
    {
        protected readonly IUnitOfWork<CompanyApplicationModel> _uow = uow;
        protected readonly IValidator<Company> _validator = validator;
        public async Task<bool> Execute(CompanyApplicationModel input)
        {
            input.Code = "COM" + DateTime.Now.ToString("ddmmyyHHmmss");

            _validator.ValidateAndThrow(input.ToCompany());

            await _uow.Repository.InsertAsync(input);
            await _uow.CommitAsync();

            return true;
        }
    }
}
