using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ApiApp.Models.Core
{
    [DataContract]
    public class Award
    {
        [Key, Required, Column(Order = 0), RegularExpression(Event.SKUREGEX), MaxLength(Event.SKULENGTH), DataMember]
        public string EventSku { get; set; }
        [ForeignKey(nameof(EventSku)), IgnoreDataMember]
        public virtual Event Event { get; set; }

        [Key, Required, Column(Order = 1), DataMember]
        public string Name { get; set; }

        [Key, Required, Column(Order = 2), RegularExpression(Team.NUMREGEX), MaxLength(Team.NUMLENGTH), DataMember]
        public string TeamNumber { get; set; }
        [ForeignKey(nameof(TeamNumber)), IgnoreDataMember]
        public virtual Team Team { get; set; }

        [DataMember]
        public virtual ICollection<Event> QualifiesFor { get; set; }
    }
}