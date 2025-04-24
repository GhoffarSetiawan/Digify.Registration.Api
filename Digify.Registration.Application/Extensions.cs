using Digify.Registration.Application.Models;
using Digify.Registration.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Application
{
    public static class Extensions
    {
        public static Company ToCompany(this CompanyApplicationModel model)
        {
            return new Company() { Id = model.Id, CompanyName= model.CompanyName, NPWP = model.NPWP, DirectorName =  model.DirectorName, PICName = model.PICName, Email = model.Email, PhoneNumber = model.PhoneNumber, DocumentNPWPName = model.DocumentNPWPName, DocumentPowerOfAttorneyName = model.DocumentPowerOfAttorneyName, DocumentNPWP = model.DocumentNPWP, DocumentPowerOfAttorney = model.DocumentPowerOfAttorney };
        }
    }
}
