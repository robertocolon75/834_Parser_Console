using AptusEdiParser.Models;
using AutoMapper;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(Loop2320))]
    public class _Loop2320 : CoordinationOfBenefits
    {
        public CoordinationOfBenefits COB
        {
            get
            {
                return new CoordinationOfBenefits
                {
                    CoordinationOfBenefitsCode = base.CoordinationOfBenefitsCode,
                    MemberPolicyNumber = base.MemberPolicyNumber,
                    PayerResponsibilitySequenceNumberCode = base.PayerResponsibilitySequenceNumberCode,
                    ServiceTypeCode = base.ServiceTypeCode,
                    File834Id = base.File834Id,
                    MemberId = base.MemberId,
                };
            }
        }

        //public List<CobRefs> REF { get; set; }

        public List<COBDate> DPT { get; set; }
        public List<_Loop2330> Loop2330s { get; set; }
        //  public List<_Loop2330> Loop2330s { get; set; }

        //
    }
}