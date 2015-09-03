using System;
using System.ComponentModel.DataAnnotations;

namespace ApiApp.Models.Core
{
    public class Season
    {
        [Key, Required]
        public string Name { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}