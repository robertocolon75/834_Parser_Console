using AptusEdiParser.Attributes;
using AptusEdiParser.Models;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(HD))]
    [Table("stg.HealthCoverage")]
    [IncludeInTypeMapping]
    public class HealthCoverage : Base
    {
        [Key]
        public long HealthCoverageId { get; set; }

        public long MemberId { get; set; }

        [SourceMember(nameof(HD.HD01))]
        public string MaintenanceTypeCode { get; set; }

        [SourceMember(nameof(HD.HD03))]
        public string InsuranceLineCode { get; set; }

        [SourceMember(nameof(HD.HD04))]
        public string PlanCoverageDescription { get; set; }

        [SourceMember(nameof(HD.HD05))]
        public string CoverageLevelCode { get; set; }
    }
}