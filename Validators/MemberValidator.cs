using FluentValidation;
using _834FilePareserControl.Models;

namespace _834FilePareserControl.Validators
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(item => item.MemberIndicator).NotEmpty().NotNull().WithErrorCode("INS01");
            RuleFor(item => item.IndividualRelationshipCode).NotEmpty().NotNull().WithErrorCode("INS02");
            RuleFor(item => item.MaintenanceTypeCode).NotEmpty().NotNull().WithErrorCode("INS03");
            RuleFor(item => item.MaintenanceReasonCode).NotEmpty().NotNull().WithErrorCode("INS04");
            RuleFor(item => item.BenefitStatusCode).NotEmpty().NotNull().WithErrorCode("INS05");
            RuleFor(item => item.MedicarePlanCode).NotEmpty().NotNull().WithErrorCode("INS06-1");
            RuleFor(item => item.EmploymentStatusCode).NotEmpty().NotNull().WithErrorCode("INS08");

            // RuleFor(item => item.).NotEmpty().NotNull();
        }
    }
}