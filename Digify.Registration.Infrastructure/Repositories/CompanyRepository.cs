using Digify.Registration.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Infrastructure.Repositories
{    
    public class CompanyRepository : BusinessRepositoryBase<CompanyApplicationModel>
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {

        }
    }
}
