using AptusEdiParser.Models;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(Loop2300))]
    public class _Loop2300 : HealthCoverage
    {
        public HealthCoverage HealthCoverage
        {
            get
            {
                return new HealthCoverage
                {
                    CoverageLevelCode = base.CoverageLevelCode,
                    InsuranceLineCode = base.InsuranceLineCode,
                    MaintenanceTypeCode = base.MaintenanceTypeCode,
                    PlanCoverageDescription = base.PlanCoverageDescription,
                    File834Id = base.File834Id,
                };
            }
        }

        [SourceMember(nameof(Loop2300.DTP))]
        public List<HealthCoverageDate> HealthCoverageDates { get; set; }

        public List<_Loop2310> Loop2310s { get; set; }
        public List<_Loop2320> Loop2320s { get; set; }
    }
}