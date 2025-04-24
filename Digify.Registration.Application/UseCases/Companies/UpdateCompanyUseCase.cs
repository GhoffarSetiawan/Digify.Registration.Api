using FluentValidation;
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
    public class UpdateCompanyUseCase(IUnitOfWork<CompanyApplicationModel> uow, IValidator<Company> validator) : IUseCase<CompanyApplicationModel, bool>
    {
        protected readonly IUnitOfWork<CompanyApplicationModel> _uow = uow;
        protected readonly IValidator<Company> _validator = validator;
        public async Task<bool> Execute(CompanyApplicationModel input)
        {
            CompanyApplicationModel? Company = await _uow.Repository.FindAsync(input.Id);
            if (Company != null)
            {
                _validator.ValidateAndThrow(input.ToCompany());

                Company.Code = input.Code;
                Company.CompanyName = input.CompanyName;
                Company.NPWP = input.NPWP;
                Company.DirectorName = input.DirectorName;
                Company.PICName = input.PICName;
                Company.DirectorName = input.DirectorName;
                Company.Email = input.Email;
                Company.PhoneNumber = input.PhoneNumber;
                Company.DocumentNPWP = input.DocumentNPWP;
                Company.DocumentPowerOfAttorney = input.DocumentPowerOfAttorney;
                Company.DocumentNPWPName = input.DocumentNPWPName;
                Company.DocumentPowerOfAttorneyName = input.DocumentPowerOfAttorneyName;
                Company.UpdatedDate = DateTime.Now;
                Company.UpdatedUserId = input.UpdatedUserId;

                await _uow.Repository.UpdateAsync(Company);
                await _uow.CommitAsync();
            }
            else
            {
                throw new Exception(Messages.DATA_NOT_FOUND);
            }
           
            return true;
        }
    }
}