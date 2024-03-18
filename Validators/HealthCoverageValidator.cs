using FluentValidation;
using _834FilePareserControl.Models;

namespace _834FilePareserControl.Validators
{
    public class HealthCoverageValidator : AbstractValidator<HealthCoverage>
    {
        public HealthCoverageValidator()
        {
            RuleFor(item => item.MaintenanceTypeCode).NotEmpty().NotNull().WithErrorCode("HD01");
            RuleFor(item => item.PlanCoverageDescription).NotEmpty().NotNull().WithErrorCode("HD02");
            RuleFor(item => item.PlanCoverageDescription).NotEmpty().NotNull().WithErrorCode("HD04");
        }
    }
}