using AptusEdiParser.Attributes;
using AptusEdiParser.Models;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(AMT))]
    [Table("stg.MemberPolicyAmount")]
    [IncludeInTypeMapping]
    public class MemberPolicyAmount : Base
    {
        [Key]
        public long MemberPolicyAmountId { get; set; }

        public long MemberProviderNameId { get; set; }

        [SourceMember(nameof(AMT.AMT01))]
        public string QualifierCode { get; set; }

        [SourceMember(nameof(AMT.AMT02))]
        public string ContractAmount { get; set; }
    }
}