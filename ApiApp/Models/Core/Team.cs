using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ApiApp.Models.Core
{
    public class Team
    {
        public const string NUMREGEX = @"^([1-9]\d{0,4}[A-Z]{0,1}|[A-Z]{1,4}\d{0,1})$";
        public const int NUMLENGTH = 6;

        [Key, Required, MaxLength(NUMLENGTH), RegularExpression(NUMREGEX)]
        public string Number { get; set; }

        public string Name { get; set; }
        public string RobotName { get; set; }

        public string Organization { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }

        public bool IsRegistered { get; set; }

        public Level Level { get; set; }
        public Program Program { get; set; }

        public DateTime LastUpdated { get; set; }

        [NotMapped]
        public List<Link> Links { get; set; }
    }
}