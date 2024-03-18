using FluentValidation;
using _834FilePareserControl.Models;

namespace _834FilePareserControl.Validators
{
    public class HealthCoveargeDateValidator : AbstractValidator<HealthCoverageDate>
    {
        public HealthCoveargeDateValidator()
        {
            RuleFor(item => item.Qualifier).NotEmpty().NotNull().WithErrorCode("DTP01");
            RuleFor(item => item.PeriodFormatQualifier).NotEmpty().NotNull().WithErrorCode("DTP02");
            RuleFor(item => item.CoveragePeriod).NotEmpty().NotNull().WithErrorCode("DPT03");
        }
    }
}