using AptusEdiParser.Models;
using AutoMapper;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(Loop2700))]
    public class _Loop2700
    {
        public string AssignedNumber { get; set; }
        public SponsorPayer N1 { get; set; }
        public N1Ref REF { get; set; }
        public N1Date DTP { get; set; }
    }
}