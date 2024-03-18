using AptusEdiParser.Attributes;
using AptusEdiParser.Models;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(REF))]
    public class REFS : Base
    {
        [SourceMember(nameof(REF.REF01))]
        public string Qualifier { get; set; }

        [SourceMember(nameof(REF.REF02))]
        public string Identifier { get; set; }
    }

    [AutoMap(typeof(REF))]
    [Table("stg.HeaderRef")]
    [IncludeInTypeMapping]
    public class HeaderRef : REFS
    {
        [Key]
        public long HeaderRefId { get; set; }

        public long HeaderId { get; set; }
    }

    [AutoMap(typeof(REF))]
    [Table("stg.MemberRef")]
    [IncludeInTypeMapping]
    public class InsRefs : REFS
    {
        [Key]
        public long MemberRefId { get; set; }

        public long MemberId { get; set; }
        //public long ParentMemberId { get; set; }
    }

    [AutoMap(typeof(REF))]
    [Table("stg.CoordinationOfBenefitsRef")]
    [IncludeInTypeMapping]
    public class CobRefs : REFS
    {
        [Key]
        public long CoordinationOfBenefitsRefId { get; set; }

        public long CoordinationOfBenefitsId { get; set; }
    }

    [AutoMap(typeof(REF))]
    [Table("stg.SponsorPayerRef")]
    [IncludeInTypeMapping]
    public class N1Ref : REFS
    {
        [Key]
        public long SponsorPayerRefId { get; set; }

        public long SponsorPayerId { get; set; }
    }
}