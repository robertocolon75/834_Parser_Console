using FluentValidation;
using _834FilePareserControl.Models;

namespace _834FilePareserControl.Validators
{
    public class InterchangeControlHeaderValidator : AbstractValidator<InterchangeControlHeader>
    {
        public InterchangeControlHeaderValidator()
        {
            RuleFor(item => item.AuthorizationInformationQualifier).Matches("00").WithErrorCode("ISA01");
            RuleFor(item => item.AuthorizationInformation).Matches("          ").WithErrorCode("ISA02");
            RuleFor(item => item.SecurityInformationQualifier).Matches("00").WithErrorCode("ISA03");
            RuleFor(item => item.SecurityInformation).Matches("          ").WithErrorCode("ISA04");
            RuleFor(item => item.SenderInterchangeIDQualifier).Matches("ZZ").WithErrorCode("ISA05");
            RuleFor(item => item.InterchangeSenderID).NotEmpty().NotNull().WithErrorCode("ISA06");
            RuleFor(item => item.ReceiverInterchangeIDQualifier).Matches("ZZ").WithErrorCode("ISA07");
            RuleFor(item => item.InterchangeReceiverID).NotEmpty().NotNull().WithErrorCode("ISA08");
            RuleFor(item => item.InterchangeDate).NotEmpty().NotNull().WithErrorCode("ISA09");
            RuleFor(item => item.InterchangeTime).NotEmpty().NotNull().WithErrorCode("ISA10");
            RuleFor(item => item.RepetitionSeparator).NotEmpty().NotNull().WithErrorCode("ISA11");
            RuleFor(item => item.InterchangeControlVersionNumber).Matches("00501").WithErrorCode("ISA12");
            RuleFor(item => item.InterchangeControlNumber).NotEmpty().NotNull().WithErrorCode("ISA13");
            RuleFor(item => item.AcknowledgementRequested).NotEmpty().NotNull().WithErrorCode("ISA14");
            RuleFor(item => item.UsageIdentifier).NotEmpty().NotNull().WithErrorCode("ISA15");
            RuleFor(item => item.ComponentElementSeparator).NotEmpty().NotNull().WithErrorCode("ISA16");

            RuleFor(item => item.FGH).SetValidator(new FunctionalGroupHeaderValidator());
        }
    }
}