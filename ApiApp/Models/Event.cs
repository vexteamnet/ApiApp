using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiApp.Models
{
    public class Event
    {
        public const string SKUREGEX = @"^RE-(VRC|VEXU|VIQC)-[0,1]\d-\d{4}$";
        public const int SKULENGTH = 17;

        [Key, Required, MaxLength(SKULENGTH), RegularExpression(SKUREGEX)]
        public string Sku { get; set; }

        public string Name { get; set; }

        public Program Program { get; set; }
        public Level Levels { get; set; }

        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }

        public string Season { get; set; }

        public Venue Venue { get; set; }

        public string Description { get; set; }

        public Contact Contact { get; set; }

        public string Agenda { get; set; }

        public virtual ICollection<Division> Divisions { get; set; }

        public virtual ICollection<Award> Awards { get; set; }
    }

    [ComplexType]
    public class Venue
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }

    [ComplexType]
    public class Contact
    {
        public string Name { get; set; }
        public string Title { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}
