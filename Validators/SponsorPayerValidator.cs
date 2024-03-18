using FluentValidation;
using _834FilePareserControl.Models;

namespace _834FilePareserControl.Validators
{
    public class SponsorPayerValidator : AbstractValidator<SponsorPayer>
    {
        public SponsorPayerValidator()
        {
            RuleFor(item => item.EntityIdentifierCode).NotEmpty().NotNull().WithErrorCode("N101").When(item => item.EntityIdentifierCode == "IN");
            RuleFor(item => item.PlanSponsorName).NotEmpty().NotNull().WithErrorCode("N102").When(item => item.EntityIdentifierCode == "IN");
            RuleFor(item => item.IdentificationCodeQualifier).NotEmpty().NotNull().WithErrorCode("N103").When(item => item.EntityIdentifierCode == "IN");
            RuleFor(item => item.SponsorIdentifier).NotEmpty().NotNull().WithErrorCode("N104").When(item => item.EntityIdentifierCode == "IN");
        }
    }
}