using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ApiApp.Models.Core
{
    [DataContract, Serializable]
    public class Event
    {
        public const string SKUREGEX = @"^RE-(VRC|VEXU|VIQC|TSA)-[0,1]\d-\d{4}$";
        public const int SKULENGTH = 17;

        [Key, Required, MaxLength(SKULENGTH), RegularExpression(SKUREGEX), DataMember]
        public string Sku { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Program Program { get; set; }
        [DataMember]
        public Level Levels { get; set; }

        [DataMember]
        public DateTime? Start { get; set; }
        [DataMember]
        public DateTime? Finish { get; set; }

        [DataMember]
        public string Season { get; set; }

        [DataMember]
        public Venue Venue { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Contact Contact { get; set; }

        [DataMember]
        public string Agenda { get; set; }

        [DataMember]
        public ICollection<Division> Divisions { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<Award> Awards { get; set; }
    }

    [ComplexType, DataContract, Serializable]
    public class Venue
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Region { get; set; }
        [DataMember]
        public string Country { get; set; }
    }

    [ComplexType, DataContract, Serializable]
    public class Contact
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Title { get; set; }
        [EmailAddress, DataMember]
        public string Email { get; set; }
        [Phone, DataMember]
        public string Phone { get; set; }
    }
}