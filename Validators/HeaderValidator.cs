using FluentValidation;
using _834FilePareserControl.Models;

namespace _834FilePareserControl.Validators
{
    public class HeaderValidator : AbstractValidator<Headers>
    {
        public HeaderValidator()
        {
            RuleFor(item => item.TransactionSetIdentifierCode).NotEmpty().NotNull().WithErrorCode("ST01");
            RuleFor(item => item.TransactionSetControlNumber).NotEmpty().NotNull().WithErrorCode("ST02");
            RuleFor(item => item.ImplementationGuideVersionName).NotEmpty().NotNull().WithErrorCode("ST03");

            RuleFor(item => item.TransactionSegmentCount).NotEmpty().NotNull().WithErrorCode("SE01");
            RuleFor(item => item.TransactionSetControlNumber2).NotEmpty().NotNull().WithErrorCode("SE02");

            RuleFor(item => item).Must(item => item.TransactionSetControlNumber == item.TransactionSetControlNumber2).WithErrorCode("ST02=SE02");

            RuleFor(item => item.TransactionSetPurposeCode).NotEmpty().NotNull().WithErrorCode("BGN01");
            RuleFor(item => item.TransactionSetReferenceNumber).NotEmpty().NotNull().WithErrorCode("BGN02");
            RuleFor(item => item.TransactionSetCreationDate).NotEmpty().NotNull().WithErrorCode("BGN03");
            RuleFor(item => item.TransactionSetCreationTime).NotEmpty().NotNull().WithErrorCode("BGN04");
            RuleFor(item => item.ActionCode).NotEmpty().NotNull().WithErrorCode("BGN08");

            RuleFor(item => item.ReferenceIdentificationQualifier).NotEmpty().NotNull().WithErrorCode("REF01");
            RuleFor(item => item.MasterPolicyNumber).NotEmpty().NotNull().WithErrorCode("REF02");

            RuleForEach(item => item.Loop2000).SetValidator(new _Loop2000Validator());
        }
    }
}