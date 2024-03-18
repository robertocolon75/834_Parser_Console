using AptusEdiParser.Models;
using AutoMapper;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(INS))]
    public class _Loop2000 : Member
    {
        public List<InsDate> DTP { get; set; }

        public Member INS
        {
            get
            {
                return new Member
                {
                    BenefitStatusCode = base.BenefitStatusCode,
                    EmploymentStatusCode = base.EmploymentStatusCode,
                    IndividualRelationshipCode = base.IndividualRelationshipCode,
                    MaintenanceReasonCode = base.MaintenanceReasonCode,
                    MaintenanceTypeCode = base.MaintenanceTypeCode,
                    MedicarePlanCode = base.MedicarePlanCode,
                    MemberIndividualDeathDate = base.MemberIndividualDeathDate,
                    MemberIndicator = base.MemberIndicator,
                    PeriodFormatQualifier = base.PeriodFormatQualifier,
                    File834Id = base.File834Id,
                };
            }
        }

        //[SourceMember(nameof(Loop2000.Loop2100s))]
        public List<_Loop2100> Loop2100s { get; set; }

        public List<_Loop2300> Loop2300s { get; set; }
        public List<_Loop2700> loop2700s { get; set; }
        public InsRefs REF { get; set; }

        public List<InsRefs> SupplementalREF { get; set; }
        //public List<_Loop2310> Loop2310s { get; set; }
        //public List<_Loop2320> Loop2320s { get; set; }
        //public List<_Loop2330> Loop2330s { get; set; }
    }
}