using FluentValidation;
using _834FilePareserControl.Models;

namespace _834FilePareserControl.Validators
{
    public class ProviderChangeReasonValidator : AbstractValidator<ProviderChangeReason>
    {
        public ProviderChangeReasonValidator()
        {
            RuleFor(item => item.ActionCode).NotEmpty().NotNull().WithErrorCode("PLA01");
            RuleFor(item => item.IdentifierCode).NotEmpty().NotNull().WithErrorCode("PLA02");
            RuleFor(item => item.EffectiveDate).NotEmpty().NotNull().WithErrorCode("PLA03");
            RuleFor(item => item.MaintenanceReasonCode).NotEmpty().NotNull().WithErrorCode("PLA05");
        }
    }
}