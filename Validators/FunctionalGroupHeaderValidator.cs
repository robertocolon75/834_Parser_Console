using FluentValidation;
using _834FilePareserControl.Models;

namespace _834FilePareserControl.Validators
{
    public class FunctionalGroupHeaderValidator : AbstractValidator<FunctionalGroupHeader>
    {
        public FunctionalGroupHeaderValidator()
        {
            RuleFor(item => item.FunctionalIDCode).NotEmpty().NotNull().WithErrorCode("GS01");
            RuleFor(item => item.ApplicationSendersCode).NotEmpty().NotNull().WithErrorCode("GS02");
            RuleFor(item => item.ApplicationReceiversCode).NotEmpty().NotNull().WithErrorCode("GS03");
            RuleFor(item => item.GSDate).NotEmpty().NotNull().WithErrorCode("GS04");
            RuleFor(item => item.GSTime).NotEmpty().NotNull().WithErrorCode("GS05");
            RuleFor(item => item.GroupControlNumber).NotEmpty().NotNull().WithErrorCode("GS06");
            RuleFor(item => item.ResponsibleAgencyCode).NotEmpty().NotNull().WithErrorCode("GS07");
            RuleFor(item => item.VersionCode).NotEmpty().NotNull().WithErrorCode("GS08");

            RuleFor(item => item.Headers).SetValidator(new HeaderValidator());
        }
    }
}