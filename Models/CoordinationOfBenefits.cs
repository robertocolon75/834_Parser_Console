using AptusEdiParser.Attributes;
using AptusEdiParser.Models;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(COB))]
    [Table("stg.CoordinationOfBenefits")]
    [IncludeInTypeMapping]
    public class CoordinationOfBenefits : Base
    {
        [SourceMember(nameof(COB.COB03))]
        public string CoordinationOfBenefitsCode { get; set; }

        [Key]
        public long CoordinationOfBenefitsId { get; set; }

        public long MemberId { get; set; }

        [SourceMember(nameof(COB.COB02))]
        public string MemberPolicyNumber { get; set; }

        [SourceMember(nameof(COB.COB01))]
        public string PayerResponsibilitySequenceNumberCode { get; set; }

        [SourceMember(nameof(COB.COB04))]
        public string ServiceTypeCode { get; set; }
    }
}