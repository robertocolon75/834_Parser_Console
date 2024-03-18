﻿using AptusEdiParser.Attributes;
using AptusEdiParser.Models;
using _834FilePareserControl.Models;
using AutoMapper.Configuration.Annotations;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _834FileParserConsole.Models
{
    [AutoMap(typeof(NM1))]
    [Table("stg.CoordinationOfBenefitsRef")]
    [IncludeInTypeMapping]
    public class CoordinationOfBenefitsRef : Base
    {
        [Key]
        public long CoordinationOfBenefitsRefId { get; set; }

        public long CoordinationOfBenefitsId { get; set; }

        [SourceMember(nameof(NM1.NM101))]
        public string IdentifierCode { get; set; }

        [SourceMember(nameof(NM1.NM102))]
        public string TypeQualifier { get; set; }

        [SourceMember(nameof(NM1.NM103))]
        public string LastName { get; set; }

        [SourceMember(nameof(NM1.NM104))]
        public string FirstName { get; set; }

        [SourceMember(nameof(NM1.NM105))]
        public string MiddleName { get; set; }

        [SourceMember(nameof(NM1.NM106))]
        public string NamePrefix { get; set; }

        [SourceMember(nameof(NM1.NM108))]
        public string IdentificationCodeQualifier { get; set; }

        [SourceMember(nameof(NM1.NM109))]
        public string Identifier { get; set; }

        [SourceMember(nameof(NM1.NM110))]
        public string EntityRelationshipCode { get; set; }
    }
}