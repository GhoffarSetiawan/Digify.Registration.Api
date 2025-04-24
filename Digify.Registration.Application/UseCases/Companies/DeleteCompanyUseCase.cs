using Digify.Registration.Application.Models;
using Digify.Registration.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Application.UseCases.Companies
{
    public class DeleteCompanyUseCase(IUnitOfWork<CompanyApplicationModel> uow) : IUseCase<DeleteParameter, bool>
    {
        protected readonly IUnitOfWork<CompanyApplicationModel> _uow = uow;
        public async Task<bool> Execute(DeleteParameter input)
        {
            await _uow.Repository.DeleteAsync(input.Id, input.UserId);
            await _uow.CommitAsync();

            return true;
        }
    }
}