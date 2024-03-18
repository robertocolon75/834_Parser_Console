using AptusEdiParser.Attributes;
using AptusEdiParser.Models;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(DTP))]
    public class Dates : Base
    {
        [SourceMember(nameof(DTP.DTP01))]
        public string Qualifier { get; set; }

        [SourceMember(nameof(DTP.DTP02))]
        public string PeriodFormatQualifier { get; set; }

        [SourceMember(nameof(DTP.DTP03))]
        public string PeriodOrDate { get; set; }
    }

    [Table("stg.EffectiveDate")]
    [IncludeInTypeMapping]
    public class HeaderDate : Dates
    {
        [Key]
        [Ignore]
        public long EffectiveDateId { get; set; }

        [Ignore]
        public long HeaderId { get; set; }

        //[Ignore]
        //public string Parent { get; set; } = "Header";
    }

    [Table("stg.MemberDate")]
    [IncludeInTypeMapping]
    public class InsDate : Dates
    {
        [Key]
        [Ignore]
        public long MemberDateId { get; set; }

        [Ignore]
        public long MemberId { get; set; }

        //[Ignore]
        //public string Parent { get; set; } = "Ins";
    }

    [Table("stg.SponsorPayerDate")]
    [IncludeInTypeMapping]
    public class N1Date : Dates //Loop2700
    {
        [Key]
        [Ignore]
        public long SponsorPayerDateId { get; set; }

        [Ignore]
        public long SponsorPayerId { get; set; }

        //[Ignore]
        //public string Parent { get; set; } = "SponsorPayer";
    }

    [Table("stg.CordinationOfBenefitsDate")]
    [IncludeInTypeMapping]
    public class COBDate : Dates
    {
        [Key]
        [Ignore]
        public long CordinationOfBenefitsDateId { get; set; }

        [Ignore]
        public long CoordinationOfBenefitsId { get; set; }

        //[Ignore]
        //public string Parent { get; set; } = "COB";
    }
}