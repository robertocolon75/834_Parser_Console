using AptusEdiParser.Attributes;
using AptusEdiParser.Models;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(DMG))]
    [Table("stg.MemberDemographic")]
    [IncludeInTypeMapping]
    public class MemberDemographics : Base
    {
        [Key]
        public long MemberDemographicId { get; set; }

        public long MemberProviderNameId { get; set; }

        [SourceMember(nameof(DMG.DMG01))]
        public string PeriodFormatQualifier { get; set; }

        [SourceMember(nameof(DMG.DMG02))]
        public string DOB { get; set; }

        [SourceMember(nameof(DMG.DMG03))]
        public string GenderCode { get; set; }

        [SourceMember(nameof(DMG.DMG04))]
        public string MaritalStatusCode { get; set; }

        [SourceMember(nameof(DMG.DMG05))]
        public string RaceOrEthnicity { get; set; }
    }
}