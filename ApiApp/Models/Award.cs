using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiApp.Models
{
    public class Award
    {
        [Key, Required, Column(Order = 0), RegularExpression(Event.SKUREGEX), MaxLength(Event.SKULENGTH)]
        public string EventSku { get; set; }
        [ForeignKey(nameof(EventSku))]
        public virtual Event Event { get; set; }

        [Key, Required, Column(Order = 1)]
        public string Name { get; set; }

        [Key, Required, Column(Order = 2), RegularExpression(Team.NUMREGEX), MaxLength(Team.NUMLENGTH)]
        public string TeamNumber { get; set; }
        [ForeignKey(nameof(TeamNumber))]
        public virtual Team Team { get; set; }

        public virtual ICollection<Event> QualifiesFor { get; set; }
    }
}
