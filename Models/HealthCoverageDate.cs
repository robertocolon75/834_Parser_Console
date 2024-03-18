using AptusEdiParser.Attributes;
using AptusEdiParser.Models;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(DTP))]
    [Table("stg.HealthCoverageDate")]
    [IncludeInTypeMapping]
    public class HealthCoverageDate : Base

    {
        [Key]
        public long HealthCoverageDateId { get; set; }

        public long HealthCoverageId { get; set; }

        [SourceMember(nameof(DTP.DTP01))]
        public string Qualifier { get; set; }

        [SourceMember(nameof(DTP.DTP02))]
        public string PeriodFormatQualifier { get; set; }

        [SourceMember(nameof(DTP.DTP03))]
        public string CoveragePeriod { get; set; }
    }
}