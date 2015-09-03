using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ApiApp.Models.Core
{
    [DataContract, Serializable]
    public class Division
    {
        [Key, Column(Order = 0), Required, RegularExpression(Event.SKUREGEX), MaxLength(Event.SKULENGTH), DataMember]
        public string EventSku { get; set; }
        [ForeignKey(nameof(EventSku)), IgnoreDataMember]
        public virtual Event Event { get; set; }

        [Key, Column(Order = 1), Required, DataMember]
        public string Name { get; set; }
    }
}