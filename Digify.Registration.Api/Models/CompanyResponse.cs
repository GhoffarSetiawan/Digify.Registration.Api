using Digify.Registration.Core.Entities;

namespace Digify.Registration.Api.Models
{
    public record CompanyResponse
    {
        public required Guid Id { get; set; }
        public required string Code { get; set; }
        public required string CompanyName { get; set; }
        public required string NPWP { get; set; }
        public required string DirectorName { get; set; }
        public required string PICName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string DocumentNPWPName { get; set; }
        public required string DocumentPowerOfAttorneyName { get; set; }
    }
}
