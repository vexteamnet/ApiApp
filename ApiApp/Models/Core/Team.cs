using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Runtime.Serialization;

namespace ApiApp.Models.Core
{
    [DataContract, KnownType(typeof(SerializableDynamic))]
    public class Team
    {
        public const string NUMREGEX = @"^([1-9]\d{0,4}[A-Z]{0,1}|[A-Z]{1,4}\d{0,1})$";
        public const int NUMLENGTH = 6;

        [Key, Required, MaxLength(NUMLENGTH), RegularExpression(NUMREGEX), DataMember]
        public string Number { get; set; }

        [DataMember(Order = 0)]
        public string Name { get; set; }
        [DataMember(Order = 1)]
        public string RobotName { get; set; }

        [DataMember(Order = 2)]
        public string Organization { get; set; }
        [DataMember(Order = 2)]
        public string City { get; set; }
        [DataMember(Order = 2)]
        public string Region { get; set; }
        [DataMember(Order = 2)]
        public string Country { get; set; }

        [DataMember(Order = 2)]
        public bool IsRegistered { get; set; }

        [DataMember(Order = 2)]
        public Level Level { get; set; }
        [DataMember(Order = 2)]
        public Program Program { get; set; }

        [DataMember(Order = 199)]
        public DateTime LastUpdated { get; set; }

        [NotMapped, DataMember(Order = 200)]
        public dynamic Links { get; set; }
    }
}