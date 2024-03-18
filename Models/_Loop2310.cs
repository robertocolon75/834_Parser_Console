using AptusEdiParser.Models;
using AutoMapper;

namespace _834FilePareserControl.Models
{
    [AutoMap(typeof(Loop2310))]
    public class _Loop2310 : LX
    {
        public string AssignedNumber { get; set; }

        public MemberProviderName NM1 { get; set; }
        public MemPrvN3 N3 { get; set; }
        public MemPrvN4 N4 { get; set; }
        public List<MemPrvPer> PER { get; set; }
        public ProviderChangeReason PLA { get; set; }
    }
}