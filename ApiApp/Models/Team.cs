using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiApp.Models
{
    public class Team
    {
        public const string REGEX = @"^([1-9]\d{0,3}[A-Z]{0,1}|[A-Z]{1,4}\d{0,1})$";

        [Key, Required, MaxLength(5), RegularExpression(REGEX)]
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
    }
}
