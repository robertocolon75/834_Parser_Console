using AptusEdiParser.Attributes;
using AptusEdiParser.Models;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(INS))]
    [Table("stg.Member")]
    [IncludeInTypeMapping]
    public class Member : Base
    {
        [Key]
        public long MemberId { get; set; }

        [SourceMember(nameof(INS.INS01))]
        public string MemberIndicator { get; set; }

        [SourceMember(nameof(INS.INS02))]
        public string IndividualRelationshipCode { get; set; }

        [SourceMember(nameof(INS.INS03))]
        public string MaintenanceTypeCode { get; set; }

        [SourceMember(nameof(INS.INS04))]
        public string MaintenanceReasonCode { get; set; }

        [SourceMember(nameof(INS.INS05))]
        public string BenefitStatusCode { get; set; }

        [SourceMember(nameof(INS.INS06))]
        public string MedicarePlanCode { get; set; }

        [SourceMember(nameof(INS.INS08))]
        public string EmploymentStatusCode { get; set; }

        [SourceMember(nameof(INS.INS11))]
        public string PeriodFormatQualifier { get; set; }

        [SourceMember(nameof(INS.INS12))]
        public string MemberIndividualDeathDate { get; set; }
    }
}