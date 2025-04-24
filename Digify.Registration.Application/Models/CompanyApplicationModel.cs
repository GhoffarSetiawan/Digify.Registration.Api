using Digify.Registration.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digify.Registration.Application.Models
{
    public class CompanyApplicationModel : ApplicationModelBase
    {
        public required string Code { get; set; }
        public required string CompanyName { get; set; }
        public required string NPWP { get; set; }
        public required string DirectorName { get; set; }
        public required string PICName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required byte[] DocumentNPWP { get; set; }
        public required byte[] DocumentPowerOfAttorney { get; set; }
        public required string DocumentNPWPName { get; set; }
        public required string DocumentPowerOfAttorneyName { get; set; }
    }
}
